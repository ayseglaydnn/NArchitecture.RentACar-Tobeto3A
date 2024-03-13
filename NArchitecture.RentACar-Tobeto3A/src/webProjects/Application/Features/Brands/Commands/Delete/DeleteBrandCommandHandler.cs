using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<DeleteBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _brandRepository.GetAsync(predicate: brand => brand.Id == request.Id);

        CheckIfBrandExists(brand);

        var deletedBrand = await _brandRepository.DeleteAsync(brand);

        var response = _mapper.Map<DeleteBrandResponse>(deletedBrand);

        return response;
    }

    private void CheckIfBrandExists(Brand brand)
    {
        if (brand is null) throw new ArgumentException("Brand does not exist.");
    }
}

