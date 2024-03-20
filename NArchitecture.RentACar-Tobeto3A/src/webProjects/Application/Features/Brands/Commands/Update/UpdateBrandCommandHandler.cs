using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<UpdateBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        Brand updateToBrand = await _brandRepository.GetAsync(predicate: brand => brand.Id == request.Id);

        CheckIfBrandExists(updateToBrand);

        _mapper.Map(request, updateToBrand);

        await _brandRepository.UpdateAsync(updateToBrand);

        var response = _mapper.Map<UpdateBrandResponse>(updateToBrand);

        return response;

    }

    private void CheckIfBrandExists(Brand brand)
    {
        if (brand is null) throw new ArgumentException("Brand does not exist.");
    }
}
