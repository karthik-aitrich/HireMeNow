using _Hire_Me_Now_.API.JobCategoryss.DTO.RequestObject;
using _Hire_Me_Now_.API.JobCategoryss.DTO.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.JobCategorys.DTO;

namespace _Hire_Me_Now_.API.JobCategoryss.Helper
{
    public class JobCategoryMappingProfile:Profile
    {
        public JobCategoryMappingProfile()
        {
            CreateMap<JobCategory, JobCategorysDto>();
            CreateMap<JobCategorysDto, JobCategory>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<JobCategoryRequestObject,JobCategorysDto>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<JobCategorysDto, JobCategoryResponseObject>();
        }
    }
}
