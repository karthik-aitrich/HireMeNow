using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services.JobsApplication.JobProviderApplication.Interface
{
    public interface IJobProviderApplicationRepository
    {
        Task<List<Domain.Models.JobApplication>> GetByProviderIdAsync(Guid providerId);

        Task<Domain.Models.JobApplication?> GetByIdAsync(Guid applicationId);

        Task UpdateAsync(Domain.Models.JobApplication application);

    }
}
