
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.SoftDelete;

public class SoftDeleteModelCommandHandler : IRequestHandler<SoftDeleteModelCommand, SoftDeleteModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public SoftDeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }
    public async Task<SoftDeleteModelResponse> Handle(SoftDeleteModelCommand request, CancellationToken cancellationToken)
    {
        var model = await _modelRepository.GetAsync(predicate: model => model.Id == request.Id);

        CheckIfModelExists(model);

        var deletedModel = await _modelRepository.SoftDeleteAsync(model);

        var response = _mapper.Map<SoftDeleteModelResponse>(deletedModel);

        return response;
    }

    private void CheckIfModelExists(Model model)
    {
        if (model is null) throw new ArgumentException("Model does not exist.");
    }
}
