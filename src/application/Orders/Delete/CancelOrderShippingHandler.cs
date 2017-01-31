using MediatR;

namespace application.Orders.Delete
{
    public class CancelOrderShippingHandler : IRequestHandler<CancelOrderShippingRequest,CancelOrderShippingResult>
    {
        public CancelOrderShippingResult Handle(CancelOrderShippingRequest request)
        {
            //do some logic to see if the shipping can be stopped

            return new CancelOrderShippingResult();
        }
    }
}
