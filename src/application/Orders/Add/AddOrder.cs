using System;
using FluentValidation;
using MediatR;

namespace application.Orders.Add
{
    public class AddOrderRequest : IRequest<AddOrderResult>
    {
        public AddOrderRequest(string customerNumber, string partNumber, int quantity)
        {
            CustomerNumber = customerNumber;
            PartNumber = partNumber;
            Quantity = quantity;
        }

        public string CustomerNumber { get; }
        public string PartNumber { get; }
        public int Quantity { get; }
    }

    public class AddOrderHandler:IRequestHandler<AddOrderRequest,AddOrderResult>
    {
        readonly IMediator _mediator;

        public AddOrderHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public AddOrderResult Handle(AddOrderRequest message)
        {
            var result = new AddOrderResult {OrderNumber = "Test Order",ExpectedShipDate = DateTime.Now.AddDays(15)};

            _mediator.Publish(new OrderAddedNotification(result.OrderNumber));

            return result;
        }
    }

    public class AddOrderResult
    {
        public string OrderNumber { get; set; }

        public DateTime ExpectedShipDate { get; set; }

    }

    public class AddOrderValidator : AbstractValidator<AddOrderRequest>
    {
        public AddOrderValidator()
        {
            RuleFor(x => x.CustomerNumber).NotEmpty().WithMessage("Customer # not supplied");
            RuleFor(x => x.PartNumber).NotEmpty().WithMessage("Part # not supplied");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}
