using _Hire_Me_Now_.API.SystemUserss.DTO.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.SystemUsers.DTO;

namespace _Hire_Me_Now_.API.SystemUserss.Helper
{
    public class SystemUserMappingProfile:Profile
    {
        public SystemUserMappingProfile()
        {
            CreateMap<SystemUser, SystemUsersDto>();
            CreateMap<SystemUsersDto, SystemUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<SystemUsersDto, SystemUserResponseObject>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        }
    }
}
