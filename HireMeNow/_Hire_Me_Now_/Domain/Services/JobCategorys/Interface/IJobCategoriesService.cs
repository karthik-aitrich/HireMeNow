using Domain.Models;
using Domain.Services.JobCategorys.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobCategorys.Interface
{
    public interface IJobCategoriesService
    {
        Task<JobCategorysDto> AddJobCategoryAsync(JobCategorysDto jobCategorysDto);
        Task<IEnumerable<JobCategorysDto>> GeAlltJobCategoriesAsync();
        Task<JobCategorysDto?> GetJobCategoryByIdAsync(Guid id);
        Task<bool> UpdateJobCategoryAsync(Guid id, JobCategorysDto jobCategorysDto);
        Task<bool> DeleteJobCategoryAsync(Guid id);
    }
}
