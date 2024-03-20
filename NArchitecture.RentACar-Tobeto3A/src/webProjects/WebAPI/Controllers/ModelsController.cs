using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetAll;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.SoftDelete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Queries.GetAll;
using Application.Features.Models.Queries.GetById;
using Application.Features.Models.Queries.GetListDynamic;
using Application.Features.Models.Queries.GetListPagination;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ModelsController : BaseController
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateModelCommand command)
    {
        return Created("", await Mediator.Send(command));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete([FromBody] DeleteModelCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("SoftDelete/{id}")]
    public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteModelCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateModelCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllModelQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdModelQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetListPagination([FromQuery] PageRequest pageRequest)
    {
        GetListByPaginationModelQuery query = new() { PageRequest = pageRequest };
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("dynamic")]
    public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        GetListByDynamicModelQuery dynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
        var result = await Mediator.Send(dynamicQuery);
        return Ok(result);
    }
}
