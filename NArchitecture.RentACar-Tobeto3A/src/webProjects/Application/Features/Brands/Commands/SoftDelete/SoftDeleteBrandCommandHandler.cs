using Application.Features.Brands.Commands.Delete;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.SoftDelete;

public class SoftDeleteBrandCommandHandler : IRequestHandler<SoftDeleteBrandCommand, SoftDeleteBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public SoftDeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<SoftDeleteBrandResponse> Handle(SoftDeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _brandRepository.GetAsync(predicate: brand => brand.Id == request.Id);

        CheckIfBrandExists(brand);

        var deletedBrand = await _brandRepository.SoftDeleteAsync(brand);

        var response = _mapper.Map<SoftDeleteBrandResponse>(deletedBrand);

        return response;
    }

    private void CheckIfBrandExists(Brand brand)
    {
        if (brand is null) throw new ArgumentException("Brand does not exist.");
    }
}
