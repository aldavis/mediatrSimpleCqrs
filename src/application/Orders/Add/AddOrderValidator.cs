using System.Collections.Generic;
using domain.Model.OrderRoot;
using FluentValidation;

namespace application.Orders.Add
{
    public class AddOrderValidator : AbstractValidator<AddOrderRequest>
    {
        //TODO add validation that product and customers actually exist, use Dapper to get the data
        public AddOrderValidator()
        {
            RuleFor(x => x.Order.Customer.Id).GreaterThan(0).WithMessage("CustomerId not supplied");

            RuleFor(x => x.Order.Items).Must(BeAvailable);

        }

        private bool BeAvailable(IList<OrderItem> items)
        {
            foreach (var item in items)
            {
                //do whatever logic we need to determine if the product can be ordered
            }

            return true;
        }
    }
}