using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.SoftDelete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Dtos;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;


namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, CreateModelCommand>().ReverseMap();
        CreateMap<Model, CreateModelResponse>().ReverseMap();

        CreateMap<Model, DeleteModelResponse>().ReverseMap();

        CreateMap<Model, SoftDeleteModelResponse>().ReverseMap();

        CreateMap<Model, UpdateModelCommand>().ReverseMap();
        CreateMap<Model, UpdateModelResponse>().ReverseMap();

        CreateMap<Model, GetModelResponse>().ReverseMap();
        //CreateMap<Model, GetModelResponse>()
        //    .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();
        CreateMap<IPaginate<Model>, GetListResponse<GetModelResponse>>().ReverseMap();

        CreateMap<List<Model>, List<GetModelResponse>>().ReverseMap();

    }
}
