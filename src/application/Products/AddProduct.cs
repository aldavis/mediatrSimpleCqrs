using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;

namespace application.Products
{
    public class AddProductRequest : IRequest<AddProductResult>
    {
    }

    public class AddProductResult
    {
        public string ProductId { get; set; }

        public string ProductNumber { get; set; }

        public string Message { get; set; }
    }

    public class AddProductRequestPreProcessor : IRequestPreProcessor<AddProductRequest>
    {
        public Task Process(AddProductRequest request)
        {
            return Task.FromResult(IsAuthorized(request));

        }

        private bool IsAuthorized(AddProductRequest request)
        {
            //check to see if the user has sufficient rights to perform this request
            return true;
        }
    }

    public class AddProductRequestHandler : IRequestHandler<AddProductRequest, AddProductResult>
    {
        public AddProductResult Handle(AddProductRequest message)
        {
            //do the work to add the product
            return new AddProductResult { ProductId = "1", ProductNumber = "AAA", Message = "Message Set in Handler" };
        }
    }

    public class AddProductPostProcessor :IRequestPostProcessor<AddProductRequest,AddProductResult>
    {
        public Task Process(AddProductRequest request, AddProductResult response)
        {
            response.Message += "\r\nMessage appended to in Post Processor";

            return Task.FromResult(response);
        }
    }
}
