using Domain.Services.AdminDashboards.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AdminDashboards.Interface
{
    public interface IAdminDashboardService
    {
        Task<AdminDashboardsDto> GetDashboardsDataAsync();
    }
}
