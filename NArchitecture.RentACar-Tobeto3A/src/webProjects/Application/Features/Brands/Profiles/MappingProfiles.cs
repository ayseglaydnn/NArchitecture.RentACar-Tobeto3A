using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.SoftDelete;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;


namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        
        CreateMap<Brand, DeleteBrandResponse>().ReverseMap();

        CreateMap<Brand, SoftDeleteBrandResponse>().ReverseMap();

        CreateMap<Brand, GetListBrandResponse>().ReverseMap();
        CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();

    }
}
