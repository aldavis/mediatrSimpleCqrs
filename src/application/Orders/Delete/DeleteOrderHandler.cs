using MediatR;

namespace application.Orders.Delete
{
    public class DeleteOrderHandler:IRequestHandler<DeleteOrderRequest,DeleteOrderResult>
    {
        readonly IMediator _mediator;

        public DeleteOrderHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public DeleteOrderResult Handle(DeleteOrderRequest message)
        {
            var result = new DeleteOrderResult();

            /*lets assume that deleting an order is a complex process which involves several steps
            in those types of situations the outermost handler(this one for example) becomes more of a composite
            or order of operation coordinator.  The overall process can be completed by child handlers*/

            //handlers that could be considered "general use" such as basic crud operations can be re-used by composite handlers such as this one

            //see if we can cancel the shipping
            var cancelShippingResponse = _mediator.Send(new CancelOrderShippingRequest(message.OrderId));


            var refundCustomerResponse = _mediator.Send(new RefundCustomerRequest(message.OrderId));

            //keep adding handlers as needed to handle the complexity in order to keep from a single handler getting too big

            return result;
        }
    }
}
