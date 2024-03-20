using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreateModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }
    public async Task<CreateModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        Model mappedModel = _mapper.Map<Model>(request);

        Model createdModel = await _modelRepository.AddAsync(mappedModel);

        CreateModelResponse response = _mapper.Map<CreateModelResponse>(createdModel);

        return response;
    }
}
