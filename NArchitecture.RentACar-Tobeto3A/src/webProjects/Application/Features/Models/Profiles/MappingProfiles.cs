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

        CreateMap<Model, GetListModelResponse>()
            .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();
        CreateMap<IPaginate<Model>, GetListResponse<GetListModelResponse>>().ReverseMap();

    }
}
