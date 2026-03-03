using _Hire_Me_Now_.API.JobSeekerApplication.Dto.ResponseObjetcs;
using AutoMapper;
using Domain.Models;
using Domain.Services.JobsApplication.JobProviderApplication.Dto;
using Hire_Me_Now.API.JobProviderApplication.Dto.RequestObject;
using Hire_Me_Now.API.JobProviderApplication.Dto.ResponseObject;

namespace Hire_Me_Now.API.JobProviderApplication.Helper
{
    public class JobProviderApplicationProfile:Profile
    {
        public JobProviderApplicationProfile()
        {
            CreateMap<JobApplication, JobProviderApplicationDto>();
            CreateMap<JobApplication, ApplyJobDto>();
            CreateMap<JobProviderApplicationStatusRequest, ApplyJobDto>();

            CreateMap<JobProviderApplicationDto,
                      JobProviderApplicationResponse>()

                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString())
                );
        }
    }
}
