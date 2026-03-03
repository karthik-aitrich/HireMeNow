using Domain.Models;
using Domain.Services.JobSeekers.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeekers.Repository
{
    public class JobSeekerJobRepository:IJobSeekerJobRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public JobSeekerJobRepository(
            DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<List<JobPost>> GetAllJobsAsync()
        {
            return await _context.JobPosts
                .OrderByDescending(j => j.PostedDate)
                .ToListAsync();
        }

        public async Task<JobPost?> GetJobByIdAsync(Guid jobId)
        {
            return await _context.JobPosts
                .FirstOrDefaultAsync(j => j.Id == jobId);
        }

    }
}
