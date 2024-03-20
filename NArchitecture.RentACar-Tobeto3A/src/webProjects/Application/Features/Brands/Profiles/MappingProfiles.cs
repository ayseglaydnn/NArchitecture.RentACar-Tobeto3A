using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.SoftDelete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Dtos;
using AutoMapper;
using Core.Application.Responses;
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

        CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
        CreateMap<Brand, UpdateBrandResponse>().ReverseMap();

        CreateMap<Brand, GetBrandResponse>().ReverseMap();
        CreateMap<IPaginate<Brand>, GetListResponse<GetBrandResponse>>().ReverseMap();

        CreateMap<List<Brand>, List<GetBrandResponse>>().ReverseMap();

    }
}
