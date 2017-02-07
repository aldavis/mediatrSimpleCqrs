using System.Threading.Tasks;
using System.Web.Http;
using application.Products;
using MediatR;

namespace webApi.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> Add(AddProductRequest request)
        {
            var result =  await _mediator.Send(request);

            return Ok(result);
        }
    }
}
