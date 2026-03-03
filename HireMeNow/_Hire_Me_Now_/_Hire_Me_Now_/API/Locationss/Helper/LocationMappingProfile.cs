using _Hire_Me_Now_.API.Locationss.DTO.RequestObject;
using _Hire_Me_Now_.API.Locationss.DTO.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.Locations.DTO;

namespace _Hire_Me_Now_.API.Locationss.Helper
{
    public class LocationMappingProfile:Profile
    {
        public LocationMappingProfile() 
        {
            CreateMap<Location, LocationsDto>();
            CreateMap<LocationsDto, Location>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<LocationRequestObject, LocationsDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());       //ignores id

            CreateMap<LocationsDto, LocationResponseObject>();

        }
    }
}
