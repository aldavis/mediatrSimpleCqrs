using System;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace application.Orders.Add
{
    public class AddOrderRequest : IRequest<AddOrderResult>
    {
        public AddOrderRequest(int customerId, string partNumber, int quantity)
        {
            CustomerId = customerId;
            PartNumber = partNumber;
            Quantity = quantity;
        }

        public int CustomerId { get; }
        public string PartNumber { get; }
        public int Quantity { get; }
    }

    public class AddOrderHandler:IRequestHandler<AddOrderRequest,AddOrderResult>
    {
        readonly IMediator _mediator;
        private readonly IValidator<AddOrderRequest> _validator;

        public AddOrderHandler(IMediator mediator, IValidator<AddOrderRequest> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public AddOrderResult Handle(AddOrderRequest message)
        {
            _validator.ValidateAndThrow(message);

            //do logic to persist the order record

            var result = new AddOrderResult { OrderNumber = "Test Order", ExpectedShipDate = DateTime.Now.AddDays(15) };

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
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("CustomerId not supplied");
            RuleFor(x => x.PartNumber).NotEmpty().WithMessage("Part # not supplied");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}
