using AutoMapper;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Models;
using Domain.Services.JobPosts.DTO;
using Domain.Services.JobPosts.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobPosts.Service
{
    public class JobPostsService : IJobPostsService
    {
        private readonly IJobPostsRepository _jobPostsRepository;
        private readonly IMapper _mapper;

        public JobPostsService(IJobPostsRepository jobPostsRepository, IMapper mapper)
        {
            _jobPostsRepository = jobPostsRepository;
            _mapper = mapper;
        }

        public async Task<JobPostsDto> CreateJobAsync(JobPostsDto dto, Guid userId)
        {
            var job = _mapper.Map<JobPost>(dto);

            job.PostedDate = DateTime.UtcNow;
            job.PostedBy = userId;

            if (job.JobResponsibilities != null)
            {
                foreach(var responsibility in job.JobResponsibilities)
                {
                    responsibility.JobPost = job.Id;
                }
            }

            await _jobPostsRepository.CreateJobAsync(job);
            return _mapper.Map<JobPostsDto>(job);
            
        }

        public async Task<List<JobPostsDto>> GetMyJobsAsync(Guid userId)
        {
            var jobs=await _jobPostsRepository.GetJobByUserIdAsync(userId);
            return _mapper.Map<List<JobPostsDto>>(jobs);
        }

        public async Task<JobPostsDto?> GetJobByIdAsync(Guid id, Guid userId)
        {
            var job = await _jobPostsRepository.GetJobByIdAsync(id);

            if(job == null || job.PostedBy!=userId)
            {
                return null;
            }

            return _mapper.Map<JobPostsDto>(job);
        }

        public async Task<bool> UpdateJobAsync(Guid id, JobPostsDto dto, Guid userId)
        {
            var job = await _jobPostsRepository.GetJobByIdAsync(id);

            if (job == null || job.PostedBy != userId)
            {
                return false;
            }
            _mapper.Map(dto, job);
            await _jobPostsRepository.UpdateJobAsync(job);
            return true;
        }

        public async Task<bool> DeleteJobAsync(Guid id, Guid userId)
        {
            var job = await _jobPostsRepository.GetJobByIdAsync(id);

            if(job==null || job.PostedBy!=userId)
            {
                return false; 
            }

            await _jobPostsRepository.DeleteJobAsync(id);
            return true;
        }

        public async Task<IEnumerable<JobPostsDto>> GetAllJobsAsync()
        {
            var job=await _jobPostsRepository.GetAllJobsAsync();
            return _mapper.Map<IEnumerable<JobPostsDto>>(job);
        }


        public async Task<bool> ApproveJobAsync(Guid id)
        {
            var job = await _jobPostsRepository.GetJobByIdAsync(id);

            if (job == null)
                throw new NotFoundException($"Job with this {id} not found.");

            job.Status = JobStatus.Approved;

            await _jobPostsRepository.UpdateJobAsync(job);
            return true;
        }

        public async Task<bool> RejectJobAsync(Guid id)
        {
            var job = await _jobPostsRepository.GetJobByIdAsync(id);

            if (job == null)
                throw new NotFoundException($"Job with this {id} not found.");

            job.Status = JobStatus.Rejected;

            await _jobPostsRepository.UpdateJobAsync(job);
            return true;
        }

        public async Task<bool> BlockJobAsync(Guid id)
        {
            var job = await _jobPostsRepository.GetJobByIdAsync(id);

            if (job == null)
                throw new NotFoundException($"Job with this {id} not found.");

            job.IsBlocked = true;
            await _jobPostsRepository.UpdateJobAsync(job);
            return true;
        }

        public async Task<bool> UnblockJobAsync(Guid id)
        {
            var job = await _jobPostsRepository.GetJobByIdAsync(id);

            if (job == null)
                throw new NotFoundException($"Job with this {id} not found.");

            job.IsBlocked = false;
            await _jobPostsRepository.UpdateJobAsync(job);
            return true;
        }
    }
}
