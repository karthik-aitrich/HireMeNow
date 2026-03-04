using _Hire_Me_Now_.API.AdminDashboardss.Helper;
using _Hire_Me_Now_.API.AuditLogss.Helper;
using _Hire_Me_Now_.API.Industryss.Helper;
using _Hire_Me_Now_.API.Interviews.Helper;
using _Hire_Me_Now_.API.JobCategoryss.Helper;
﻿using _Hire_Me_Now_.API.JobSeekerApplication.Helper;
using _Hire_Me_Now_.API.Locationss.Helper;
using _Hire_Me_Now_.API.Qualificationss.Helper;
using _Hire_Me_Now_.API.Resumess.Helper;
using _Hire_Me_Now_.API.SaveJobss.Helper;
using _Hire_Me_Now_.API.SystemUserss.Helper;
using _Hire_Me_Now_.API.WorkExperiencess.Helper;
using Domain.Models;
using Domain.Models;
using Domain.Services.AdminDashboards.Interface;
using Domain.Services.AdminDashboards.Repository;
using Domain.Services.AdminDashboards.Service;
using Domain.Services.AuditLogs.Interface;
using Domain.Services.AuditLogs.Repository;
using Domain.Services.Industrys.Interface;
using Domain.Services.Industrys.Repository;
using Domain.Services.Industrys.Service;
//using Domain.Services.CandidateReviews.Service;
using Domain.Services.Interviews.Interface;
using Domain.Services.JobApplication.Service;
using Domain.Services.JobCategorys.Interface;
using Domain.Services.JobCategorys.Repository;
using Domain.Services.JobCategorys.Service;
using Domain.Services.JobPosts.Interface;
using Domain.Services.JobPosts.Repository;
using Domain.Services.JobPosts.Service;
using Domain.Services.JobsApplication.JobProviderApplication.Interface;
using Domain.Services.JobsApplication.JobSeekerApplication.Interface;
using Domain.Services.JobsApplication.JobSeekerApplication.Service;
using Domain.Services.JobsApplication.Repository;
using Domain.Services.JobSeekers.Interface;
using Domain.Services.JobSeekers.Repository;
using Domain.Services.JobSeekers.Service;
using Domain.Services.Locations.Interface;
using Domain.Services.Locations.Repository;
using Domain.Services.Locations.Service;
using Domain.Services.Qualifications.Interface;
using Domain.Services.Qualifications.Repository;
using Domain.Services.Qualifications.Service;
using Domain.Services.Resumes.Interface;
using Domain.Services.Resumes.Repository;
using Domain.Services.Resumes.Service;
using Domain.Services.SavedJobs.Interface;
using Domain.Services.SavedJobs.Repository;
using Domain.Services.SavedJobs.Service;
using Domain.Services.SystemUsers.Interface;
using Domain.Services.SystemUsers.Repository;
using Domain.Services.SystemUsers.Service;
using Domain.Services.WorkExperiences.Interface;
using Domain.Services.WorkExperiences.Repository;
using Domain.Services.WorkExperiences.Service;
using Hire_Me_Now.API.JobProviderApplication.Helper;
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
            services.AddAutoMapper(typeof(SavedJobMappingProfile));

            services.AddScoped<IAdminDashboardRepository, AdminDashboardRepository>();      //admindashboard
            services.AddScoped<IAdminDashboardService, AdminDashboardService>();
            services.AddAutoMapper(typeof(AdminDashboardMappingProfile));

            services.AddScoped<ISystemUsersRepository, SystemUsersRepository>();        //systemuser
            services.AddScoped<ISystemUsersService, SystemUsersService>();
            services.AddAutoMapper(typeof(SystemUserMappingProfile));

            services.AddScoped<IAuditLogsRepository, AuditLogsRepository>();    //auditlog
            services.AddScoped<IAuditLogsService, AuditLogsService>();
            services.AddAutoMapper(typeof(AuditLogsMappingProfile));
            

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
     //       services.AddDbContext<DbHireMeNowWebApiContext>(options =>
     //options.UseSqlServer(
     //    config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IJobProviderApplicationService,JobProviderApplicationService>();
            services.AddScoped<IJobProviderApplicationRepository,JobProviderApplicationRepository>();


            services.AddScoped<IJobSeekerApplicationRepository, JobsSeekerApplicationRepository>();

            services.AddScoped<IJobSeekerJobRepository,JobSeekerJobRepository>();
            services.AddScoped<IJobSeekerJobService, JobSeekerJobService>();


            services.AddScoped<IJobSeekerApplicationService, JobSeekerApplicationService>();


            services.AddAutoMapper(typeof(JobSeekerApplicationProfile));
            services.AddAutoMapper(typeof(JobProviderApplicationProfile));

            services.AddAutoMapper(typeof(ResumeMappingProfile));
            services.AddAutoMapper(typeof(ExperienceMappingProfile));
            services.AddAutoMapper(typeof(QualificationMappingProfile));
            services.AddAutoMapper(typeof(InterviewMappingProfile));
          



            services.AddScoped<IInterviewRepository, InterviewRepository>();
            services.AddScoped<IInterviewService, InterviewService>();


          

            services.AddScoped<IQualificationsRepository, QualificationsRepository>();
            services.AddScoped<IQualificationsService, QualificationsService>();

            services.AddScoped<IResumeRepository, ResumesRepository>();
            services.AddScoped<IResumesService, ResumesService>();


            services.AddScoped<IWorkExperiencesService, WorkExperiencesService>();
            services.AddScoped<IWorkExperienceRepository, WorkExperiencesRepository>();


            services.AddScoped<IEmailService, EmailService>();


            return services;


        }
    }
}
