using Domain.Services.JobsApplication.JobProviderApplication.Dto;
using Domain.Services.JobsApplication.JobSeekerApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobsApplication.JobSeekerApplication.Interface
{
    public interface IJobSeekerApplicationService
    {
        Task<List<JobSeekerApplicationDto>>
       GetApplicationsAsync(Guid seekerId);

        Task<bool> ApplyAsync(JobSeekerApplicationDto dto);

        Task<bool> WithdrawAsync(
            JobSeekerWithdrawApplicationDto dto);
    }
}
