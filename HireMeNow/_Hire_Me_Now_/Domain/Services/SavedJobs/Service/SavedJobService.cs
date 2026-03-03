using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Services.SavedJobs.Dto;
using Domain.Services.SavedJobs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SavedJobs.Service
{
    public class SavedJobService:ISavedJobService
    {
        private readonly IMapper _mapper;
        private readonly ISavedJobRepository _savedJobRepository;

        public SavedJobService(IMapper mapper, ISavedJobRepository savedJobRepository)
        {
            _mapper = mapper;
            _savedJobRepository = savedJobRepository;
        }

        public async Task<SavedJobDto> SaveJobAsync(SavedJobDto savedJobDto)
        {
            var existing = await _savedJobRepository.GetSavedJobAsync(savedJobDto.JobPostId, savedJobDto.systemUserId);

            if (existing == null)
            {

                var jobSaved = _mapper.Map<SavedJob>(savedJobDto);

                jobSaved.IsSaved = true;
                jobSaved.SavedOn = DateTime.UtcNow;

                await _savedJobRepository.SaveJobAsync(jobSaved);
                return _mapper.Map<SavedJobDto>(jobSaved);
            }

            else
            {
                existing.IsSaved = true;
                await _savedJobRepository.UpdateJobAsync(existing);
                return _mapper.Map<SavedJobDto>(existing);
            }
        }


        public async Task<SavedJobDto> UnsaveJobAsync(SavedJobDto savedJobDto)
        {
            var existing = await _savedJobRepository.GetSavedJobAsync(savedJobDto.JobPostId, savedJobDto.systemUserId);

            if (existing == null)
            {
                throw new NotFoundException($"Saved job not found");
            }

            existing.IsSaved = false;
            await _savedJobRepository.UpdateJobAsync(existing);
            return _mapper.Map<SavedJobDto>(existing);
        }

        public async Task<IEnumerable<SavedJobDto>> GetMySavedJobsAsync(Guid systemUserId)
        {
            var savedJobs = await _savedJobRepository.GetMySavedJobsAsync(systemUserId);


            return _mapper.Map<IEnumerable<SavedJobDto>>(savedJobs);
        }

        public async Task<SavedJobDto?> GetSavedJobByIdAsync(Guid savedJobId, Guid systemUserId)
        {
            var saved = await _savedJobRepository.GetSavedJobByIdAsync(savedJobId, systemUserId);

            if (saved == null)
                return null;

            return _mapper.Map<SavedJobDto>(saved);
        }
    }
}
