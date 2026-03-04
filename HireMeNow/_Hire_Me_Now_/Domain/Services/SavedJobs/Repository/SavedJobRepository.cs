using Domain.Models;
using Domain.Services.SavedJobs.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SavedJobs.Repository
{
    public class SavedJobRepository:ISavedJobRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public SavedJobRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<SavedJob> SaveJobAsync(SavedJob savedJob)
        {
            _context.SavedJobs.Add(savedJob);
            await _context.SaveChangesAsync();
            return savedJob;
        }

        public async Task<SavedJob> UpdateJobAsync(SavedJob savedJob)
        {
            _context.SavedJobs.Update(savedJob);
            await _context.SaveChangesAsync();
            return savedJob;
        }

        public async Task<IEnumerable<SavedJob>> GetMySavedJobsAsync(Guid systemUserId)
        {
            var savedJob=await _context.SavedJobs.Include(x=>x.JobPost).Where(x=>x.JobPostId== systemUserId && x.IsSaved).ToListAsync();
            return savedJob;
        }

        public async Task<SavedJob?> GetSavedJobByIdAsync(Guid savedJobId, Guid systemUserId)
        {
            var savedJob =await _context.SavedJobs.Include(x => x.JobPost).FirstOrDefaultAsync(x => x.Id == savedJobId && x.JobPostId == systemUserId && x.IsSaved);
            return savedJob;
        }

        public async Task<SavedJob?> GetSavedJobAsync(Guid jobId, Guid systemUserId)
        {
            var savedJob = await _context.SavedJobs.FirstOrDefaultAsync(x => x.JobPostId == jobId && x.JobPostId == systemUserId);
            return savedJob;
        }
    }
}
