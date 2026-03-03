using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobPosts.Interface
{
    public interface IJobPostsRepository
    {
        Task<JobPost> CreateJobAsync(JobPost jobPost);
        Task<List<JobPost>> GetJobByUserIdAsync(Guid userId);
        Task<JobPost?> GetJobByIdAsync(Guid id);
        Task UpdateJobAsync(JobPost jobPost);
        Task DeleteJobAsync(Guid id);
        Task<IEnumerable<JobPost>> GetAllJobsAsync();
    }
}
