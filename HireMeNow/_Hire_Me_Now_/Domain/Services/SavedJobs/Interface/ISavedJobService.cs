using Domain.Models;
using Domain.Services.SavedJobs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SavedJobs.Interface
{
    public interface ISavedJobService
    {
        Task<SavedJobDto> SaveJobAsync(SavedJobDto savedJobDto);
        Task<SavedJobDto> UnsaveJobAsync(SavedJobDto savedJobDto);
        Task<IEnumerable<SavedJobDto>> GetMySavedJobsAsync(Guid systemUserId);
        Task<SavedJobDto?> GetSavedJobByIdAsync(Guid savedJobId, Guid systemUserId);
    }
}
