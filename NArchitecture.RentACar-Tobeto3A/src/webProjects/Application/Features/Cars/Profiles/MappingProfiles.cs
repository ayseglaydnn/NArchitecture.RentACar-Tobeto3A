using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.SoftDelete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Dtos;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;


namespace Application.Features.Cars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Car, CreateCarCommand>().ReverseMap();
        CreateMap<Car, CreateCarResponse>().ReverseMap();

        CreateMap<Car, DeleteCarResponse>().ReverseMap();

        CreateMap<Car, SoftDeleteCarResponse>().ReverseMap();

        CreateMap<Car, UpdateCarCommand>().ReverseMap();
        CreateMap<Car, UpdateCarResponse>().ReverseMap();

        CreateMap<Car, GetCarResponse>()
            .ForMember(destinationMember: c => c.ModelName, memberOptions: opt => opt.MapFrom(c => c.Model.Name))
            .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Model.Brand.Name));
        CreateMap<IPaginate<Car>, GetListResponse<GetCarResponse>>().ReverseMap();

        CreateMap<List<Car>, List<GetCarResponse>>().ReverseMap();

    }
}
