using MediatR;

namespace application.Products
{
    public class AddProductRequestHandler:IRequestHandler<AddProductRequest,AddProductResult>
    {
        public AddProductResult Handle(AddProductRequest message)
        {
            //do the work to add the product
            return  new AddProductResult {ProductId = "1",ProductNumber = "AAA",Message = "Message Set in Handler"};
        }
    }
}
