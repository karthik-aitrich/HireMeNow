using Domain.Enums;
using Domain.Models;
using Domain.Services.AdminDashboards.Dto;
using Domain.Services.AdminDashboards.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AdminDashboards.Repository
{
    public class AdminDashboardRepository:IAdminDashboardRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public AdminDashboardRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<AdminDashboard> GetDashboardsDataAsync()
        {
            return new AdminDashboard
            {
                TotalJobs = await _context.JobPosts.CountAsync(),

                PendingJobs = await _context.JobPosts.CountAsync(j => j.Status == JobStatus.Pending),


                ApprovedJobs = await _context.JobPosts.CountAsync(j => j.Status == JobStatus.Approved),


                RejectedJobs = await _context.JobPosts.CountAsync(j => j.Status == JobStatus.Rejected),


                BlockedJobs = await _context.JobPosts.CountAsync(j => j.IsBlocked),


                TotalJobSeekers = await _context.JobSeekers.CountAsync(),

                TotalJobProviders = await _context.CompanyUsers.CountAsync(),

                //TotalApplications = await _context.JobApplications.CountAsync(),
       
            };
        }
    }
}
