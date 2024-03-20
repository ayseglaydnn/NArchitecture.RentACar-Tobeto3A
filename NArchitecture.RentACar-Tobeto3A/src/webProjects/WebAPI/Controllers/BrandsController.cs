using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.SoftDelete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetListDynamic;
using Application.Features.Brands.Queries.GetListPagination;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteBrandCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBrandQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdBrandQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> GetListPagination([FromQuery] PageRequest pageRequest)
        {
            GetListPaginationBrandQuery query = new() { PageRequest = pageRequest };
            GetListResponse<GetBrandResponse> result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Dynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListBrandDynamicQuery brandDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            GetListResponse<GetBrandResponse> result = await Mediator.Send(brandDynamicQuery);
            return Ok(result);
        }
    }
}
