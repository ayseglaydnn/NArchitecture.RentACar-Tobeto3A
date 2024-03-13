using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
