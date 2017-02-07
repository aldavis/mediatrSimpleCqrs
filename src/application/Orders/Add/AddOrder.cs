using System;
using application.Orders.Add.Notification;
using application.Persistence;
using domain.Model.OrderRoot;
using FluentValidation;
using MediatR;

namespace application.Orders.Add
{
    public class AddOrderHandler:IRequestHandler<AddOrderRequest,AddOrderResult>
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

        public AddOrderResult Handle(AddOrderRequest message)
        {
            _validator.ValidateAndThrow(message);

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

            _mediator.Publish(new OrderAddedNotification(result.OrderNumber));

            return result;
        }
    }
}