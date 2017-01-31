using System.Threading.Tasks;
using MediatR;

namespace application.Customers.Get
{
    public class GetCustomersWithOpenOrdersRequest:IRequest<GetCustomersWithOpenOrdersResult>
    {
    }

    public class GetCustomersWithOpenOrdersResult   
    {
        public int TotalCount { get; set; }

    }

    public class GetCustomersWithOpenOrdersHandler:IAsyncRequestHandler<GetCustomersWithOpenOrdersRequest,GetCustomersWithOpenOrdersResult>
    {
        public Task<GetCustomersWithOpenOrdersResult> Handle(GetCustomersWithOpenOrdersRequest message)
        {
            return Task.FromResult(new GetCustomersWithOpenOrdersResult {TotalCount = 500});
        }
    }
}
