
using _Hire_Me_Now_.API.Interviews.Helper;
using _Hire_Me_Now_.API.Qualificationss.Helper;
using _Hire_Me_Now_.API.Resumess.Helper;
using _Hire_Me_Now_.API.WorkExperiencess.Helper;
using Domain.Models;

//using Domain.Services.CandidateReviews.Service;
using Domain.Services.Interviews.Interface;
//using Domain.Services.Interviews.Repository;
//using Domain.Services.Interviews.Service;
using Domain.Services.Qualifications.Interface;
using Domain.Services.Qualifications.Repository;
using Domain.Services.Qualifications.Service;
using Domain.Services.Resumes.Interface;
using Domain.Services.Resumes.Repository;
using Domain.Services.Resumes.Service;
using Domain.Services.WorkExperiences.Interface;
using Domain.Services.WorkExperiences.Repository;
using Domain.Services.WorkExperiences.Service;
using Microsoft.EntityFrameworkCore;

namespace _Hire_Me_Now_.Extension
{
    public static class AppServiceExtension
    {
        public static IServiceCollection AddAppService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DbHireMeNowWebApiContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

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
