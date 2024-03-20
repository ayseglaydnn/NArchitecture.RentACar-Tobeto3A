using Application.Features.Models.Commands.Update;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcers.Utilities.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdateCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }
    public async Task<UpdateCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        Car updateToCar = await _carRepository.GetAsync(predicate: car => car.Id == request.Id);

        CheckIfCarExists(updateToCar);

        _mapper.Map(request, updateToCar);

        await _carRepository.UpdateAsync(updateToCar);

        var response = _mapper.Map<UpdateCarResponse>(updateToCar);

        return response;

    }

    private void CheckIfCarExists(Car car)
    {
        if (car is null) throw new ArgumentException("Car does not exist.");
    }
}
