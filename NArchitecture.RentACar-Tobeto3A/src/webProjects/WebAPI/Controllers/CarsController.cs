using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.SoftDelete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetAll;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetListDynamic;
using Application.Features.Cars.Queries.GetListPagination;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class CarsController : BaseController
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateCarCommand command)
    {
        return Created("", await Mediator.Send(command));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete([FromBody] DeleteCarCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("SoftDelete/{id}")]
    public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteCarCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateCarCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCarQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdCarQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("Pagination")]
    public async Task<IActionResult> GetListPagination([FromQuery] PageRequest pageRequest)
    {
        GetListByPaginationCarQuery query = new() { PageRequest = pageRequest };
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("Dynamic")]
    public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        GetListByDynamicCarQuery dynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
        var result = await Mediator.Send(dynamicQuery);
        return Ok(result);
    }
}
