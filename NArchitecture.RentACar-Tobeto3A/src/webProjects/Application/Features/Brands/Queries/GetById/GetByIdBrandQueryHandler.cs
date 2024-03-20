using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcers.Utilities.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetById;

public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, IDataResult<GetBrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetByIdBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<IDataResult<GetBrandResponse>> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
    {
        Brand brand = await _brandRepository.GetAsync(predicate: brand => brand.Id == request.Id);

        CheckIfBrandExists(brand);

        GetBrandResponse response = _mapper.Map<GetBrandResponse>(brand);

        return new SuccessDataResult<GetBrandResponse>(response, "Showed Successfully");
    }

    private void CheckIfBrandExists(Brand brand)
    {
        if (brand is null) throw new ArgumentException("Brand does not exist.");
    }
}
