using System.Threading.Tasks;
using System.Web.Http;
using application.Orders.Add;
using application.Orders.Delete;
using MediatR;

namespace webApi.Controllers
{
    [RoutePrefix("api/order")]
    public class OrdersController : ApiController
    {
        readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> Add(AddOrderRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(DeleteOrderRequest request)
        {
            var result = _mediator.Send(request);

            return Ok(result);
        }

    }
}
