using Application.Features.Cars.Dtos;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.Cars.Queries.GetListDynamic;

public class GetListByDynamicCarQuery : IRequest<GetListResponse<GetListCarResponse>>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}
