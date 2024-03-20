using Application.Features.Brands.Dtos;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using MediatR;


namespace Application.Features.Brands.Queries.GetListDynamic;

public class GetListBrandDynamicQuery : IRequest<GetListResponse<GetBrandResponse>>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}
