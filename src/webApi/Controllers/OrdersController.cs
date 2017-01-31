﻿using System.Web.Http;
using application.Orders.Add;
using application.Orders.Delete;
using MediatR;

namespace webApi.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(AddOrderRequest request)
        {
            var result = _mediator.Send(request);

            return Ok(result);
        }

    }
}
