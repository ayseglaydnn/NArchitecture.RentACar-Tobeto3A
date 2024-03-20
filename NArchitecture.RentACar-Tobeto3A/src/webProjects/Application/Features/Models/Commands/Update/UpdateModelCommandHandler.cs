using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcers.Utilities.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdateModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<UpdateModelResponse> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        Model updateToModel = await _modelRepository.GetAsync(predicate: model => model.Id == request.Id);

        CheckIfModelExists(updateToModel);

        _mapper.Map(request, updateToModel);

        await _modelRepository.UpdateAsync(updateToModel);

        var response = _mapper.Map<UpdateModelResponse>(updateToModel);

        return response;

    }

    private void CheckIfModelExists(Model model)
    {
        if (model is null) throw new ArgumentException("Model does not exist.");
    }
}
