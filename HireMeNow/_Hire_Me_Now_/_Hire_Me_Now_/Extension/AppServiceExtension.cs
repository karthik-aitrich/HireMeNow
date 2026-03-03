using _Hire_Me_Now_.API.JobSeekerApplication.Helper;
using Domain.Models;
using Domain.Services.JobsApplication.JobProviderApplication.Interface;
using Domain.Services.JobsApplication.JobSeekerApplication.Interface;
using Domain.Services.JobsApplication.JobSeekerApplication.Service;
using Domain.Services.JobsApplication.Repository;
using Domain.Services.JobSeekers.Interface;
using Domain.Services.JobSeekers.Repository;
using Domain.Services.JobSeekers.Service;
using Hire_Me_Now.API.JobProviderApplication.Helper;
using Microsoft.EntityFrameworkCore;

namespace _Hire_Me_Now_.Extension
{
    public static class AppServiceExtension
    {
        public static IServiceCollection AddAppService(this IServiceCollection services, IConfiguration config)
        {
            //      services.AddDbContext<DbHireMeNowWebApiContext>(options =>
            //options.UseSqlServer(
            //    config.GetConnectionString("DefaultConnection"),
            //    sqlOptions =>
            //    {
            //        sqlOptions.EnableRetryOnFailure(
            //            maxRetryCount: 5,
            //            maxRetryDelay: TimeSpan.FromSeconds(10),
            //            errorNumbersToAdd: null);
            //    }));
            services.AddDbContext<DbHireMeNowWebApiContext>(options =>
     options.UseSqlServer(
         config.GetConnectionString("DefaultConnection")));
            services.AddScoped<Domain.Services.JobsApplication.JobProviderApplication.Interface.IJobProviderApplicationService, Domain.Services.JobApplication.Service.JobProviderApplicationService>();
            services.AddScoped<IJobProviderApplicationRepository,
                              JobProviderApplicationRepository>();

            services.AddScoped<IJobSeekerApplicationRepository,
    JobsSeekerApplicationRepository>();
           services.AddScoped<IJobSeekerJobRepository,JobSeekerJobRepository>();
            services.AddScoped<IJobSeekerJobService, JobSeekerJobService>();


            services.AddScoped<IJobSeekerApplicationService,
                JobSeekerApplicationService>();

            services.AddAutoMapper(typeof(JobSeekerApplicationProfile));
            services.AddAutoMapper(typeof(JobProviderApplicationProfile));

            return services;


        }
    }
}
