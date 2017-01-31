using MediatR;

namespace application.Orders.Delete
{
    public class DeleteOrderRequest:IRequest<DeleteOrderResult>
    {
        public DeleteOrderRequest(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
