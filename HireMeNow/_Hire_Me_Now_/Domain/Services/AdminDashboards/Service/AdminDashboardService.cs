using AutoMapper;
using Domain.Services.AdminDashboards.Dto;
using Domain.Services.AdminDashboards.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AdminDashboards.Service
{
    public class AdminDashboardService:IAdminDashboardService
    {
        private readonly IAdminDashboardRepository _adminDashboardRepository;
        private readonly IMapper _mapper;

        public AdminDashboardService(IAdminDashboardRepository adminDashboardRepository,IMapper mapper)
        {
            _adminDashboardRepository = adminDashboardRepository;   
            _mapper = mapper;
        }

        public async Task<AdminDashboardsDto> GetDashboardsDataAsync()
        {
            var dashBoard=  await _adminDashboardRepository.GetDashboardsDataAsync();
            return _mapper.Map<AdminDashboardsDto>(dashBoard);
        }
    }
}
