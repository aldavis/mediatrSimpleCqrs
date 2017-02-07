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

    public class CancelOrderShippingResult
    {
        public string OrderNumber { get; set; }

    }

    public class CancelOrderShippingHandler : IRequestHandler<CancelOrderShippingRequest,CancelOrderShippingResult>
    {
        public CancelOrderShippingResult Handle(CancelOrderShippingRequest request)
        {
            //do some logic to see if the shipping can be stopped

            return new CancelOrderShippingResult();
        }
    }
}
