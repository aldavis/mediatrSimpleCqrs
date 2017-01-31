using MediatR;

namespace application.Orders.Add
{
    public class AddOrderHandler:IRequestHandler<AddOrderRequest,AddOrderResult>
    {
        public AddOrderResult Handle(AddOrderRequest message)
        {
            return new AddOrderResult();
        }
    }
}
