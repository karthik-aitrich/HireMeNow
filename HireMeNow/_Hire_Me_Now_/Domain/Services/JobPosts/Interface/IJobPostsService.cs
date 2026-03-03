using Domain.Services.JobPosts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobPosts.Interface
{
    public interface IJobPostsService
    {
        Task<JobPostsDto> CreateJobAsync(JobPostsDto dto, Guid userId);
        Task<List<JobPostsDto>> GetMyJobsAsync(Guid userId);
        Task<JobPostsDto?> GetJobByIdAsync(Guid id, Guid userId);
        Task<bool> UpdateJobAsync(Guid id, JobPostsDto dto, Guid userId);
        Task<bool> DeleteJobAsync(Guid id, Guid userId);

        Task<IEnumerable<JobPostsDto>> GetAllJobsAsync();
        Task<bool> ApproveJobAsync(Guid id);
        Task<bool> RejectJobAsync(Guid id);
        Task<bool> BlockJobAsync(Guid id);
        Task<bool> UnblockJobAsync(Guid id);


    }
}
