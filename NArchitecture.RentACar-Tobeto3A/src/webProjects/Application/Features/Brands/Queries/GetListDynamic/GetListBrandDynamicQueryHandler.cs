using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;


namespace Application.Features.Brands.Queries.GetListDynamic;

public class GetListBrandDynamicQueryHandler : IRequestHandler<GetListBrandDynamicQuery, GetListResponse<GetBrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetListBrandDynamicQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetBrandResponse>> Handle(GetListBrandDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Brand> brands = await _brandRepository.GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);
        GetListResponse<GetBrandResponse> brandListModel = _mapper.Map<GetListResponse<GetBrandResponse>>(brands);
        return brandListModel;
    }
}
