using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Services.JobCategorys.DTO;
using Domain.Services.JobCategorys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobCategorys.Service
{
    public class JobCategoriesService:IJobCategoriesService
    {
        private readonly IMapper _mapper;
        private readonly IJobCategoriesRepository _jobCategoriesRepository;

        public JobCategoriesService(IMapper mapper, IJobCategoriesRepository jobCategoriesRepository)
        {
            _mapper = mapper;
            _jobCategoriesRepository = jobCategoriesRepository;
        }

        public async Task<JobCategorysDto> AddJobCategoryAsync(JobCategorysDto jobCategorysDto)
        {
            var jobCategory = _mapper.Map<JobCategory>(jobCategorysDto);
            var result=await _jobCategoriesRepository.AddJobCategoryAsync(jobCategory);
            return _mapper.Map<JobCategorysDto>(result);
        }

        public async Task<IEnumerable<JobCategorysDto>> GeAlltJobCategoriesAsync()
        {
            var jobCategory = await _jobCategoriesRepository.GetAllJobCategoriesAsync();
            return _mapper.Map<IEnumerable<JobCategorysDto>>(jobCategory);
        }

        public async Task<JobCategorysDto?> GetJobCategoryByIdAsync(Guid id)
        {
            var jobCategory=await _jobCategoriesRepository.GetJobCategoryByIdAsync(id);

            if(jobCategory == null)
            {
                throw new NotFoundException($"Location with Id {id} not found.");
            }

            return _mapper.Map<JobCategorysDto>(jobCategory);
        }

        public async Task<bool> UpdateJobCategoryAsync(Guid id, JobCategorysDto jobCategorysDto)
        {
            var existingJobCategory = await _jobCategoriesRepository.GetJobCategoryByIdAsync(id);

            if (existingJobCategory == null)
            {
                throw new NotFoundException($"Location with Id {id} not found.");
            }

            _mapper.Map(jobCategorysDto, existingJobCategory);
            await _jobCategoriesRepository.UpdateJobCategoryAsync(existingJobCategory);
            return true;
        }

        public async Task<bool> DeleteJobCategoryAsync(Guid id)
        {
            var existingJobCategory = await _jobCategoriesRepository.GetJobCategoryByIdAsync(id);

            if (existingJobCategory == null)
            {
                throw new NotFoundException($"Location with Id {id} not found.");
            }

            await _jobCategoriesRepository.DeleteJobCategoryAsync(id);
            return true;
        }
    }
}
