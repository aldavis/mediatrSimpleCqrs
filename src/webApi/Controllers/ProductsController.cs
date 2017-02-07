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
        public IHttpActionResult Add(AddProductRequest request)
        {
            var result = _mediator.Send(request);

            return Ok(result);
        }
    }
}
