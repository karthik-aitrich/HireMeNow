using _Hire_Me_Now_.API.SavedJobss.Dto.RequestObject;
using _Hire_Me_Now_.API.SavedJobss.Dto.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.SavedJobs.Dto;

namespace _Hire_Me_Now_.API.SaveJobss.Helper
{
    public class SavedJobMappingProfile:Profile
    {
        public SavedJobMappingProfile()
        {
            CreateMap<SavedJob, SavedJobDto>().ReverseMap();

            CreateMap<SavedJobRequestObject, SavedJobDto>();
            CreateMap<SavedJobDto, SavedJobResponseObject>();
        }
    }
}
