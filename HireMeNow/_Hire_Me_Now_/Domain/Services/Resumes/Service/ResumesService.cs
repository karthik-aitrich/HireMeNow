using AutoMapper;
using Domain.Models;
using Domain.Services.Resumes.DTO;
using Domain.Services.Resumes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Resumes.Service
{
    public class ResumesService : IResumesService
    {
        private readonly IResumeRepository _repository;
        private readonly IMapper _mapper;


        public ResumesService(IResumeRepository service , IMapper mapper)
        {
            _repository = service;
            _mapper = mapper;
        }



        public async Task<ResumesDto> CreateResumeAsync(Guid userId, ResumesDto dto)
        {
            var resume = _mapper.Map<Resume>(dto);

            resume.ResumeId = Guid.NewGuid();

            resume.SeekerProfileId = userId;


            await _repository.AddResumeAsync(resume);

            return _mapper.Map<ResumesDto>(resume);
        }



        public async Task<List<ResumesDto>> GetMyResumeAsync(Guid userId)
        {
            var resume = await _repository.GetMyResumeAsync(userId);

            return _mapper.Map<List<ResumesDto>>(resume);
        }



        public async Task<ResumesDto> UpdateResumeAsync(Guid resumeId, Guid userId, ResumesDto dto)
        { 
            var resume = await _repository.GetResumeByIdAsync(resumeId);

            if (resume == null)
                throw new KeyNotFoundException("Resume not found");

            if (resume.SeekerProfileId != userId)
                throw new UnauthorizedAccessException("You cannot modify this resume");

      
            _mapper.Map(dto, resume);

          
            await _repository.UpdateResumeAsync(resume);


            return _mapper.Map<ResumesDto>(resume);
        }



        public async Task DeleteResumeAsync(Guid resumeId, Guid userId)
        {
            var resume = await _repository.GetResumeByIdAsync(resumeId);

            if (resume == null)
                throw new KeyNotFoundException("Resume not found");

            if (resume.SeekerProfileId != userId)
                throw new UnauthorizedAccessException("You cannot modify this resume");

            await _repository.DeleteResumeAsync(resume);
        }



        public async Task<IEnumerable<ResumesDto>> GetAllResumeAsync()
        {
            var resume = await _repository.GetAllResumeAsync();

            var result = _mapper.Map<List<ResumesDto>>(resume);

            return result;
        }


    }
}
