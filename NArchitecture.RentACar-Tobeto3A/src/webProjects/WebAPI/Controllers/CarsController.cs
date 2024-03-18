using Application.Features.Cars.Commands.SoftDelete;
using Application.Features.Cars.Queries.GetListDynamic;
using Application.Features.Cars.Queries.GetListPagination;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class CarsController : BaseController
{

    [HttpDelete("SoftDelete/{id}")]
    public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteCarCommand command)
    {
        return Ok(await Mediator.Send(command));
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
