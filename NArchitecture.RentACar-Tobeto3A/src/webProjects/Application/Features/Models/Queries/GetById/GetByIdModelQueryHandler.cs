using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcers.Utilities.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Queries.GetById;

public class GetByIdModelQueryHandler : IRequestHandler<GetByIdModelQuery, IDataResult<GetModelResponse>>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetByIdModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }
    public async Task<IDataResult<GetModelResponse>> Handle(GetByIdModelQuery request, CancellationToken cancellationToken)
    {
        Model model = await _modelRepository.GetAsync(predicate: model => model.Id == request.Id);

        CheckIfModelExists(model);

        GetModelResponse response = _mapper.Map<GetModelResponse>(model);

        return new SuccessDataResult<GetModelResponse>(response, "Showed Successfully");
    }
    private void CheckIfModelExists(Model model)
    {
        if (model is null) throw new ArgumentException("Model does not exist.");
    }
}
