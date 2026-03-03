using _Hire_Me_Now_.API.Interviews.Dto.RequestObject;
using _Hire_Me_Now_.API.Interviews.Dto.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.Interviews.Dto;

namespace _Hire_Me_Now_.API.Interviews.Helper
{
    public class InterviewMappingProfile : Profile
    {
        public InterviewMappingProfile()
        {

            CreateMap<Interview, InterviewDto>().ReverseMap();

            CreateMap<InterviewRequest, InterviewDto>().ReverseMap();
            CreateMap<InterviewResponse, InterviewDto>().ReverseMap();

        }
    }
}
