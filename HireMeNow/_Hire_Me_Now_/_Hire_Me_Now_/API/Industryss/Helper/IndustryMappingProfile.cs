using _Hire_Me_Now_.API.Industryss.DTO.RequestObject;
using _Hire_Me_Now_.API.Industryss.DTO.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.Industrys.DTO;

namespace _Hire_Me_Now_.API.Industryss.Helper
{
    public class IndustryMappingProfile:Profile
    {
        public IndustryMappingProfile() 
        {
            CreateMap<Industry, IndustrysDto>();
            CreateMap<IndustrysDto, Industry>()
                .ForMember(dest=>dest.Id,opt=>opt.Ignore());        //ignores id

            CreateMap<IndustryRequestObject, IndustrysDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());   
            CreateMap<IndustrysDto, IndustryResponseObject>();
        }
    }
}
