using System.Threading.Tasks;
using MediatR.Pipeline;

namespace application.Products
{
    public class AddProductPostProcessor :IRequestPostProcessor<AddProductRequest,AddProductResult>
    {
        public Task Process(AddProductRequest request, AddProductResult response)
        {
            response.Message += "\r\nMessage appended to in Post Processor";

            return Task.FromResult(response);
        }
    }
}
