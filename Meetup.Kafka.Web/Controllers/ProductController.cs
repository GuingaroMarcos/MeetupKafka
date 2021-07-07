using MediatR;
using Meetup.Kafka.Application.Request;
using Meetup.Kafka.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.Kafka.Web.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        public ProductController()
        {

        }

        [HttpPost("NewOrder")]
        public async Task<IActionResult> NewOrder([FromServices] IMediator mediator,[FromForm] ProductRequest productRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                var ret = await mediator.Send(productRequest, cancellationToken);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest("Unable to generate the Order. reason => " + ex.Message);
            }
        }
    }
}
