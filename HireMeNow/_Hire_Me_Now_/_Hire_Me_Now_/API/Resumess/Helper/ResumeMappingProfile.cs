using _Hire_Me_Now_.API.Resumess.DTO.RequestObject;
using _Hire_Me_Now_.API.Resumess.DTO.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.Resumes.DTO;

namespace _Hire_Me_Now_.API.Resumess.Helper
{
    public class ResumeMappingProfile : Profile
    {
        public ResumeMappingProfile()
        {
            // ENTITY → SERVICE DTO
            CreateMap<Resume, ResumesDto>();

            // SERVICE DTO → ENTITY (Ignore PK)
            CreateMap<ResumesDto, Resume>()
                .ForMember(dest => dest.ResumeId, opt => opt.Ignore());

            // SERVICE DTO → RESPONSE
            CreateMap<ResumesDto, ResumeResponse>();

            // REQUEST → SERVICE DTO
            CreateMap<ResumeRequest, ResumesDto>()
                .ForMember(dest => dest.File,
                    opt => opt.MapFrom(src => ConvertToBytes(src.File)));
        }

        private byte[]? ConvertToBytes(IFormFile? file)
        {
            if (file == null)
                return null;

            using var ms = new MemoryStream();
            file.CopyTo(ms);
            return ms.ToArray();
        }
    }
}