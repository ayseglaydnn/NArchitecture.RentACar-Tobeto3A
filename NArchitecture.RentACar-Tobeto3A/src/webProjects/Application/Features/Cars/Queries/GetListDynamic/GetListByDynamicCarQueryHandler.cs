using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetListDynamic;

public class GetListByDynamicCarQueryHandler 
    : IRequestHandler<GetListByDynamicCarQuery, GetListResponse<GetListCarResponse>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetListByDynamicCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListCarResponse>> Handle(GetListByDynamicCarQuery request, 
        CancellationToken cancellationToken)
    {
        IPaginate<Car> cars = await _carRepository.GetListByDynamicAsync(request.Dynamic,
            include: c => c.Include(c => c.Model).Include(c => c.Model.Brand),
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);

        var mappedCarListModel = _mapper.Map<GetListResponse<GetListCarResponse>>(cars);

        return mappedCarListModel;
    }
}
