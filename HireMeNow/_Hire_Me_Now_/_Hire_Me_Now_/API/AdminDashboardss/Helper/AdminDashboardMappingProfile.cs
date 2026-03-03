using _Hire_Me_Now_.API.AdminDashboardss.Dto.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.AdminDashboards.Dto;

namespace _Hire_Me_Now_.API.AdminDashboardss.Helper
{
    public class AdminDashboardMappingProfile:Profile
    {
        public AdminDashboardMappingProfile() 
        {
            CreateMap<AdminDashboard, AdminDashboardsDto>().ReverseMap();
            CreateMap<AdminDashboardsDto, AdminDashboardResponseObject>();
        }
    }
}
