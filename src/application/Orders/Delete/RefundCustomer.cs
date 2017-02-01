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

    public class RefundCustomerHandler : IRequestHandler<RefundCustomerRequest, RefundCustomerResult>
    {
        public RefundCustomerResult Handle(RefundCustomerRequest request)
        {
            //do some logic to get the customers money refunded

            return new RefundCustomerResult();
        }
    }

    public class RefundCustomerResult
    {
        public decimal RefundAmount { get; set; }

    }
}
