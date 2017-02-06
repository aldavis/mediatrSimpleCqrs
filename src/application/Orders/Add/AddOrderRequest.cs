using System.Dynamic;
using domain.Model.OrderRoot;
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
}
