using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SavedJobs.Interface
{
    public interface ISavedJobRepository
    {
        Task<SavedJob> SaveJobAsync(SavedJob savedJob);
        Task<SavedJob> UpdateJobAsync(SavedJob savedJob);
        Task<IEnumerable<SavedJob>> GetMySavedJobsAsync(Guid systemUserId);
        Task<SavedJob?> GetSavedJobByIdAsync(Guid savedJobId, Guid systemUserId);
        Task<SavedJob?> GetSavedJobAsync(Guid jobId, Guid systemUserId);
    }
}
