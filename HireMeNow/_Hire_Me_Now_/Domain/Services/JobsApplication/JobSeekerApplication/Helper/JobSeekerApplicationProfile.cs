using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Services.JobsApplication.JobProviderApplication.Dto;

namespace Domain.Services.JobsApplication.JobSeekerApplication.Helper
{
    public class JobSeekerApplicationProfile:Profile
    {
        public JobSeekerApplicationProfile()
        {
            // ENTITY → DTO
            CreateMap<Domain.Models.JobApplication, JobSeekerApplicationDto>();

            // DTO → RESPONSE
         

       
        }

    }
}
