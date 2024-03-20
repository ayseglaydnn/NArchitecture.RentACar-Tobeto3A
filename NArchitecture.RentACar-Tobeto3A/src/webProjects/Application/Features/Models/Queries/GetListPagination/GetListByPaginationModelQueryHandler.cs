using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;


namespace Application.Features.Models.Queries.GetListPagination;

public class GetListByPaginationModelQueryHandler : IRequestHandler<GetListByPaginationModelQuery, GetListResponse<GetModelResponse>>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListByPaginationModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetModelResponse>> Handle(GetListByPaginationModelQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models = await _modelRepository.GetListPaginateAsync
            (index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        var paginatedModelListModel = _mapper.Map<GetListResponse<GetModelResponse>>(models);

        return paginatedModelListModel;
    }
}
