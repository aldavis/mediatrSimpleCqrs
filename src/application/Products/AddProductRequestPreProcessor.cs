using System;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace application.Products
{
    public class AddProductRequestPreProcessor:IRequestPreProcessor<AddProductRequest>
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
}
