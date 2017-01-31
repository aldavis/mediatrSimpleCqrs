using FluentValidation;

namespace application.Orders.Add
{
    public class AddOrderValidator:AbstractValidator<AddOrderRequest>
    {
        public AddOrderValidator()
        {
            RuleFor(x => x.CustomerNumber).NotEmpty().WithMessage("Customer # not supplied");
            RuleFor(x => x.PartNumber).NotEmpty().WithMessage("Part # not supplied");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}
