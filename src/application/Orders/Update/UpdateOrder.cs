using MediatR;

namespace application.Orders.Update
{
    public class UpdateOrderRequest:IRequest<UpdateOrderResponse>
    {
    }

    public class UpdateOrderHandler:IRequestHandler<UpdateOrderRequest,UpdateOrderResponse>
    {
        public UpdateOrderResponse Handle(UpdateOrderRequest message)
        {
            return new UpdateOrderResponse();
        }
    }

    public class UpdateOrderResponse    
    {
    }
}
