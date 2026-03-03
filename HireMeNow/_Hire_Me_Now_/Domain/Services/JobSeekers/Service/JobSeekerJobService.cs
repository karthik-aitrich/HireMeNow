using Domain.Models;
using Domain.Services.JobSeekers.DTO;
using Domain.Services.JobSeekers.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeekers.Service
{
    public class JobSeekerJobService:IJobSeekerJobService
    {
        private readonly IJobSeekerJobRepository _repository;
        private readonly DbHireMeNowWebApiContext _context;

        public JobSeekerJobService(
            IJobSeekerJobRepository repository,DbHireMeNowWebApiContext context)
        {
            _repository = repository;
            _context = context;

        }

        public async Task<List<JobSeekerJobDto>> GetJobsAsync()
        {
            var jobs = await _repository.GetAllJobsAsync();

            return jobs.Select(j => new JobSeekerJobDto
            {
                JobId = j.Id,
                JobTitle = j.JobTitle,
                JobSummary = j.JobSummary,
                ProviderId = j.ProviderId,
                PostedDate = j.PostedDate
            }).ToList();
        }

        public async Task<JobSeekerJobDto?> GetJobByIdAsync(Guid jobId)
        {
            var job = await _repository.GetJobByIdAsync(jobId);

            if (job == null)
                return null;

            return new JobSeekerJobDto
            {
                JobId = job.Id,
                JobTitle = job.JobTitle,
                JobSummary = job.JobSummary,
                ProviderId = job.ProviderId,
                PostedDate = job.PostedDate
            };
        }

        public async Task<List<JobPost>> SearchJobsAsync(
    string? keyword,
    Guid? locationId,
    Guid? categoryId)
        {
            var query = _context.JobPosts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(j =>
                    j.JobTitle.Contains(keyword) ||
                    j.JobSummary.Contains(keyword));
            }

            if (locationId.HasValue)
            {
                query = query.Where(j =>
                    j.JobLocation == locationId.Value);
            }

            if (categoryId.HasValue)
            {
                query = query.Where(j =>
                    j.Category == categoryId.Value);
            }

            return await query
                .OrderByDescending(j => j.PostedDate)
                .ToListAsync();
        }


    }
}
