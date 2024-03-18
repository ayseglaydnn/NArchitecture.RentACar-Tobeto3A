using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries.GetListPagination;

public class GetListByPaginationCarQueryHandler : IRequestHandler<GetListByPaginationCarQuery, GetListResponse<GetListCarResponse>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetListByPaginationCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListCarResponse>> Handle(GetListByPaginationCarQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Car> cars = await _carRepository.GetListPaginateAsync
            (index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        var paginatedCarListModel = _mapper.Map<GetListResponse<GetListCarResponse>>(cars);

        return paginatedCarListModel;
    }
}
