using System.Threading.Tasks;
using System.Web.Http;
using application.Customers.Get;
using MediatR;

namespace webApi.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomersController : ApiController
    {
        readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("customerswithopenorders")]
        [HttpGet]
        public async Task<IHttpActionResult> CustomersWithOpenOrders()
        {
            var result = await _mediator.Send(new GetCustomersWithOpenOrdersRequest());

            return Ok(result);
        }
    }
}
