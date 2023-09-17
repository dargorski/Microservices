using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.AutoMapperProfiles;

public class PlatformsProfile : Profile
{
    public PlatformsProfile()
    {
        CreateMap<Platform, PlatformReadDto>();
        CreateMap<PlatformCreateDto, Platform>();
    }
}