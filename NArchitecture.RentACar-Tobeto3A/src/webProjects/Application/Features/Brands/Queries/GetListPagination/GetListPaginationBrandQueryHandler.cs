using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;


namespace Application.Features.Brands.Queries.GetListPagination;

public class GetListPaginationBrandQueryHandler : IRequestHandler<GetListPaginationBrandQuery, GetListResponse<GetBrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetListPaginationBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetBrandResponse>> Handle(GetListPaginationBrandQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Brand> brands = await _brandRepository.GetListPaginateAsync
            (index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        GetListResponse<GetBrandResponse> brandListModel = _mapper.Map<GetListResponse<GetBrandResponse>> (brands);
        return brandListModel;
    }
}
