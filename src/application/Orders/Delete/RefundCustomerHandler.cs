using MediatR;

namespace application.Orders.Delete
{
    public class RefundCustomerHandler : IRequestHandler<RefundCustomerRequest, RefundCustomerResult>
    {
        public RefundCustomerResult Handle(RefundCustomerRequest request)
        {
            //do some logic to get the customers money refunded

            return new RefundCustomerResult();
        }
    }
}
