using Application.Features.Models.Commands.SoftDelete;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Delete;

public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeleteModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }
    public async Task<DeleteModelResponse> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        var model = await _modelRepository.GetAsync(predicate: model => model.Id == request.Id);

        CheckIfModelExists(model);

        var deletedModel = await _modelRepository.DeleteAsync(model);

        var response = _mapper.Map<DeleteModelResponse>(deletedModel);

        return response;
    }

    private void CheckIfModelExists(Model model)
    {
        if (model is null) throw new ArgumentException("Model does not exist.");
    }
}
