using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobCategorys.Interface
{
    public interface IJobCategoriesRepository
    {
        Task<JobCategory> AddJobCategoryAsync(JobCategory jobCategory);
        Task<IEnumerable<JobCategory>> GetAllJobCategoriesAsync();
        Task<JobCategory?> GetJobCategoryByIdAsync(Guid id);
        Task UpdateJobCategoryAsync(JobCategory jobCategory);
        Task DeleteJobCategoryAsync(Guid id);
    }
}
