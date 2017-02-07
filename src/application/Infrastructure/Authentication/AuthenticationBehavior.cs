using System.Threading.Tasks;
using MediatR;

namespace application.Infrastructure.Authentication
{
    public class AuthenticationBehavior<TRequest,TResponse>:IPipelineBehavior<TRequest,TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            //do some authentication relatd stuff here

            var response = await next();

            return response;
        }
    }
}
