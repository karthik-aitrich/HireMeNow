using _Hire_Me_Now_.API.Qualificationss.DTO.RequestObject;
using _Hire_Me_Now_.API.Qualificationss.DTO.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.Qualifications.DTO;

namespace _Hire_Me_Now_.API.Qualificationss.Helper
{
    public class QualificationMappingProfile : Profile
    {
        public QualificationMappingProfile()
        {
            // ===============================
            // REQUEST -> DTO
            // ===============================
            CreateMap<QualificationRequest, QualificationsDto>();


            // ===============================
            // DTO -> RESPONSE
            // ===============================
            CreateMap<QualificationsDto, QualificationResponse>();


            // ===============================
            // ENTITY -> DTO
            // ===============================
            CreateMap<Qualification, QualificationsDto>();


            // ===============================
            // DTO -> ENTITY (FOR ADD)
            // ===============================
            CreateMap<QualificationsDto, Qualification>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Generated in service
                .ForMember(dest => dest.JobSeekerProfileId, opt => opt.Ignore()) // Set in service
                .ForMember(dest => dest.JobPostId, opt => opt.Ignore()); // Optional FK
        }
    }
}