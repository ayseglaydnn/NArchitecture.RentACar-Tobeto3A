using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        
        CreateMap<Brand, DeleteBrandResponse>().ReverseMap();

    }
}
