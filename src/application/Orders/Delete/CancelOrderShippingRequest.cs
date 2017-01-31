using MediatR;

namespace application.Orders.Delete
{
    public class CancelOrderShippingRequest : IRequest<CancelOrderShippingResult>
    {
        public CancelOrderShippingRequest(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
