using _Hire_Me_Now_.API.AdminDashboardss.Helper;
using _Hire_Me_Now_.API.AuditLogss.Helper;
using _Hire_Me_Now_.API.Industryss.Helper;
using _Hire_Me_Now_.API.JobCategoryss.Helper;
using _Hire_Me_Now_.API.Locationss.Helper;
using _Hire_Me_Now_.API.SystemUserss.Helper;
using Domain.Models;
using Domain.Services.AdminDashboards.Interface;
using Domain.Services.AdminDashboards.Repository;
using Domain.Services.AdminDashboards.Service;
using Domain.Services.AuditLogs.Interface;
using Domain.Services.AuditLogs.Repository;
using Domain.Services.Industrys.Interface;
using Domain.Services.Industrys.Repository;
using Domain.Services.Industrys.Service;
using Domain.Services.JobCategorys.Interface;
using Domain.Services.JobCategorys.Repository;
using Domain.Services.JobCategorys.Service;
using Domain.Services.JobPosts.Interface;
using Domain.Services.JobPosts.Repository;
using Domain.Services.JobPosts.Service;
using Domain.Services.Locations.Interface;
using Domain.Services.Locations.Repository;
using Domain.Services.Locations.Service;
using Domain.Services.SavedJobs.Interface;
using Domain.Services.SavedJobs.Repository;
using Domain.Services.SavedJobs.Service;
using Domain.Services.SystemUsers.Interface;
using Domain.Services.SystemUsers.Repository;
using Domain.Services.SystemUsers.Service;
using Microsoft.EntityFrameworkCore;

namespace _Hire_Me_Now_.Extension
{
    public static class AppServiceExtension
    {
        public static IServiceCollection AddAppService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DbHireMeNowWebApiContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IJobPostsRepository, JobPostsRepository>();      //jobpost
            services.AddScoped<IJobPostsService, JobPostsService>();
            services.AddAutoMapper(typeof(JobPostMappingProfile));

            services.AddScoped<ILocationsRepository, LocationsRepository>();     //location
            services.AddScoped<ILocationsService,LocationsService>();
            services.AddAutoMapper(typeof(LocationMappingProfile));

            services.AddScoped<IIndustrysRepository, IndustrysRepository>();    //industry
            services.AddScoped<IIndustrysService, IndustrysService>();
            services.AddAutoMapper(typeof (IndustryMappingProfile));

            services.AddScoped<IJobCategoriesRepository, JobCategoriesRepository>();       //jobCategory
            services.AddScoped<IJobCategoriesService, JobCategoriesService>();
            services.AddAutoMapper(typeof(JobCategoryMappingProfile));


            services.AddScoped<ISavedJobRepository,SavedJobRepository>();       //SavedJob
            services.AddScoped<ISavedJobService,SavedJobService>();
            services.AddAutoMapper(typeof(SavedJobService));

            services.AddScoped<IAdminDashboardRepository, AdminDashboardRepository>();      //admindashboard
            services.AddScoped<IAdminDashboardService, AdminDashboardService>();
            services.AddAutoMapper(typeof(AdminDashboardMappingProfile));

            services.AddScoped<ISystemUsersRepository, SystemUsersRepository>();        //systemuser
            services.AddScoped<ISystemUsersService, SystemUsersService>();
            services.AddAutoMapper(typeof(SystemUserMappingProfile));

            services.AddScoped<IAuditLogsRepository, AuditLogsRepository>();    //auditlog
            services.AddScoped<IAuditLogsService, AuditLogsService>();
            services.AddAutoMapper(typeof(AuditLogsMappingProfile));
            
            return services;
        }
    }
}
