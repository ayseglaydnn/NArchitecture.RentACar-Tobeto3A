using Application.Features.Models.Commands.SoftDelete;
using Application.Features.Models.Queries.GetListDynamic;
using Application.Features.Models.Queries.GetListPagination;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ModelsController : BaseController
{

    [HttpDelete("SoftDelete/{id}")]
    public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteModelCommand command)
    {
        return Ok(await Mediator.Send(command));
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
