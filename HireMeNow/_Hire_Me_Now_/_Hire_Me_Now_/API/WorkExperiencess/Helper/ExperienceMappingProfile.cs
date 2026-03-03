using _Hire_Me_Now_.API.WorkExperiencess.Dto.RequestObject;
using _Hire_Me_Now_.API.WorkExperiencess.Dto.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.WorkExperiences.DTO;

namespace _Hire_Me_Now_.API.WorkExperiencess.Helper
{
    public class ExperienceMappingProfile : Profile
    {
       public ExperienceMappingProfile()
        {
            CreateMap<WorkExperience, WorkExperienceDto>().ReverseMap();

            CreateMap<ExperienceRequest, WorkExperienceDto>().ReverseMap();
            CreateMap<ExperienceResponse, WorkExperienceDto>().ReverseMap();

            CreateMap<WorkExperience, WorkExperienceDto>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.WorkId))
    .ReverseMap();



            CreateMap<WorkExperienceDto, WorkExperience>()
    .ForMember(dest => dest.WorkId, opt => opt.Ignore())
    .ForMember(dest => dest.JobSeekerProfileId, opt => opt.Ignore());











        }
    }
}
