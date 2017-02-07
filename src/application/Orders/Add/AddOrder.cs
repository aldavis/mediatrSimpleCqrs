﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using application.Orders.Add.Notification;
using application.Persistence;
using domain.Model.OrderRoot;
using FluentValidation;
using MediatR;

namespace application.Orders.Add
{
    public class AddOrderRequest : IRequest<AddOrderResult>
    {
        public AddOrderRequest(Order order)
        {
            Order = order;
        }

        public Order Order { get; set; }
    }

    public class AddOrderResult
    {
        public string OrderNumber { get; set; }

        public DateTime ExpectedShipDate { get; set; }

        public decimal OrderTotal { get; set; }

    }

    public class AddOrderValidator : AbstractValidator<AddOrderRequest>
    {
        //TODO add validation that product and customers actually exist, use Dapper to get the data
        public AddOrderValidator()
        {
            RuleFor(x => x.Order.Customer.Id).GreaterThan(0).WithMessage("CustomerId not supplied");

            RuleFor(x => x.Order.Items).Must(BeAvailable);

        }

        private bool BeAvailable(ICollection<OrderItem> items)
        {
            foreach (var item in items)
            {
                //do whatever logic we need to determine if the product can be ordered
            }

            return true;
        }
    }

    public class AddOrderHandler:IAsyncRequestHandler<AddOrderRequest,AddOrderResult>
    {
        readonly IMediator _mediator;
        private readonly IValidator<AddOrderRequest> _validator;
        private readonly IEntityFrameworkContext _context;

        public AddOrderHandler(IMediator mediator, IValidator<AddOrderRequest> validator,IEntityFrameworkContext context)
        {
            _mediator = mediator;
            _validator = validator;
            _context = context;
        }

        public async Task<AddOrderResult> Handle(AddOrderRequest message)
        {
            await _validator.ValidateAndThrowAsync(message);

            var customer = _context.Customers.Find(message.Order.Customer.Id);

            var order = new Order(customer);

            foreach (var orderItem in message.Order.Items)
            {
                var lineItem = new OrderItem(_context.Products.Find(orderItem.Product.Id),orderItem.Quantity);
                order.AddItem(lineItem);
            }

            customer.Orders.Add(order);

            var orderTotal = order.CalculateTotal();
            order.Customer.DebitAccount(orderTotal);

            _context.SaveChanges();

            var result = new AddOrderResult { OrderNumber = "Test Order", ExpectedShipDate = DateTime.Now.AddDays(15),OrderTotal = order.CalculateTotal()};

            await _mediator.Publish(new OrderAddedNotification(result.OrderNumber));

            return result;
        }
    }
}