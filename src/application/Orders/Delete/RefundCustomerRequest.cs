using MediatR;

namespace application.Orders.Delete
{
    public class RefundCustomerRequest : IRequest<RefundCustomerResult>
    {
        public RefundCustomerRequest(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
