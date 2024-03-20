using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetAll;

public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, List<GetBrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetAllBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<List<GetBrandResponse>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
    {
        List<Brand> brands = await _brandRepository.GetAllAsync();

        List<GetBrandResponse> responses = _mapper.Map<List<GetBrandResponse>>(brands);

        return responses;
    }
}
