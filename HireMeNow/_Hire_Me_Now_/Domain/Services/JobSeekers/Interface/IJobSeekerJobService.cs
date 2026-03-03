using Domain.Models;
using Domain.Services.JobSeekers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeekers.Interface
{
    public interface IJobSeekerJobService
    {
        Task<List<JobSeekerJobDto>> GetJobsAsync();

        Task<JobSeekerJobDto?> GetJobByIdAsync(Guid jobId);

        Task<List<JobPost>> SearchJobsAsync(
    string? keyword,
    Guid? locationId,
    Guid? categoryId);
    }
}
