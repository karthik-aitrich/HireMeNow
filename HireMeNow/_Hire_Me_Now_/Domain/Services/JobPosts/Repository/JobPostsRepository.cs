using Domain.Models;
using Domain.Services.JobPosts.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobPosts.Repository
{
    public class JobPostsRepository:IJobPostsRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public JobPostsRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<JobPost> CreateJobAsync(JobPost job)
        {
            _context.JobPosts.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<List<JobPost>> GetJobByUserIdAsync(Guid userId)
        {
            var job= await _context.JobPosts.Where(i=>i.PostedBy==userId).ToListAsync();
            return job;
        }

        public async Task<JobPost?> GetJobByIdAsync(Guid id)
        {
            var job = await _context.JobPosts.FindAsync(id);
            return job;
        }

        public async Task UpdateJobAsync(JobPost jobPost)
        {
            _context.JobPosts.Update(jobPost);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobAsync(Guid id)
        {
            var job = await _context.JobPosts.FindAsync(id);

            if(job!=null)
            {
                _context.JobPosts.Remove(job);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<JobPost>> GetAllJobsAsync()
        {
            var job=await _context.JobPosts.ToListAsync();
            return job;
        }
    }
}
