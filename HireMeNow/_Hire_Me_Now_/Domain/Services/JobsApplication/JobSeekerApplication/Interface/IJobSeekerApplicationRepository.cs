using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services.JobsApplication.JobSeekerApplication.Interface
{
    public interface IJobSeekerApplicationRepository
    {
        Task<List<Domain.Models.JobApplication>> GetBySeekerIdAsync(Guid seekerId);

        Task<Domain.Models.JobApplication?> GetByIdAsync(Guid applicationId);

        Task AddAsync(Domain.Models.JobApplication application);

        Task UpdateAsync(Domain.Models.JobApplication application);
    }
}
