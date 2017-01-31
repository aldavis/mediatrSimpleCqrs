using System.Threading.Tasks;
using System.Web.Http;
using application.Customers.Get;
using MediatR;

namespace webApi.Controllers
{
    public class CustomersController : ApiController
    {
        readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IHttpActionResult> Get()
        {
            var result = await _mediator.Send(new GetCustomersWithOpenOrdersRequest());

            return Ok(result);
        }
    }
}
