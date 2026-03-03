using _Hire_Me_Now_.API.JobPostss.DTO.RequestObject;
using _Hire_Me_Now_.API.JobPostss.DTO.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.JobPosts.DTO;
using static _Hire_Me_Now_.API.JobPostss.DTO.ResponseObject.JobPostResponseObject;

public class JobPostMappingProfile : Profile
{
    public JobPostMappingProfile()
    {

        CreateMap<JobPostsRequestObject, JobPostsDto>();

        CreateMap<JobPost, JobPostsDto>();
        CreateMap<JobPostsDto, JobPost>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.PostedBy, opt => opt.Ignore())
            .ForMember(dest => dest.PostedDate, opt => opt.Ignore());


        CreateMap<JobResponsibilityRequest, JobResponsibilityDto>();
        CreateMap<JobResponsibilityDto, JobResponsibility>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.JobPost, opt => opt.Ignore());

        CreateMap<JobPostsDto, JobPostResponseObject>();
  
        CreateMap<JobPost, JobPostResponseObject>()
            .ForMember(dest => dest.Responsibilities,
                opt => opt.MapFrom(src => src.JobResponsibilities));

        CreateMap<JobResponsibility, JobResponsibilityResponse>();
    }
}