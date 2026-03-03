using Domain.Services.JobsApplication.JobProviderApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobsApplication.JobProviderApplication.Interface
{
    public interface IJobProviderApplicationService
    {
        Task<List<JobProviderApplicationDto>>
       GetApplicationsByProviderIdAsync(Guid providerId);

        Task<bool> UpdateApplicationStatusAsync(
            ApplyJobDto dto);
    }
}
