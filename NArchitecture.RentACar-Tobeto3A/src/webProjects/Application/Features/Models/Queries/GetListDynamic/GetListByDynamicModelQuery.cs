using Application.Features.Models.Dtos;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.Models.Queries.GetListDynamic;

public class GetListByDynamicModelQuery:IRequest<GetListResponse<GetListModelResponse>>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}
