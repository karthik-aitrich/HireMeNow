using _Hire_Me_Now_.API.AuditLogss.DTO.AuditLogsRequestObject;
using _Hire_Me_Now_.API.AuditLogss.DTO.AuditLogsResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.AuditLogs.DTO;

namespace _Hire_Me_Now_.API.AuditLogss.Helper
{
    public class AuditLogsMappingProfile:Profile
    {
        public AuditLogsMappingProfile() 
        {
            CreateMap<AuditLog,AuditLogsDto>().ReverseMap();
            CreateMap<AuditLogsRequestObject, AuditLogsDto>();
            CreateMap<AuditLogsDto, AuditLogsResponseObject>();
        }
    }
}
