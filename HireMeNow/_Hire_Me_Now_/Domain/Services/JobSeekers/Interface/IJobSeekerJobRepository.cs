using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeekers.Interface
{
    public interface IJobSeekerJobRepository
    {
        Task<List<JobPost>> GetAllJobsAsync();

        Task<JobPost?> GetJobByIdAsync(Guid jobId);
    }
}
