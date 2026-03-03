using _Hire_Me_Now_.API.JobSeekerApplication.Dto.RequestObjects;
using _Hire_Me_Now_.API.JobSeekerApplication.Dto.ResponseObjetcs;
using AutoMapper;
using Domain.Models;
using Domain.Services.JobsApplication.JobProviderApplication.Dto;

namespace _Hire_Me_Now_.API.JobSeekerApplication.Helper
{
    public class JobSeekerApplicationProfile:Profile
    {
        public JobSeekerApplicationProfile()
        {
            CreateMap<JobSeekerApplyRequest, JobSeekerApplicationDto>();
            CreateMap<JobSeekerWithdrawRequest, JobSeekerApplicationDto>();

            // Domain model -> Service DTO
            CreateMap<JobApplication, JobSeekerApplicationDto>()
                .ReverseMap();

            // Service DTO -> API Response
            CreateMap<JobSeekerApplicationDto, JobSeekerApplicationResponse>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString()) // if Status is enum
                );
        }
    }
}
