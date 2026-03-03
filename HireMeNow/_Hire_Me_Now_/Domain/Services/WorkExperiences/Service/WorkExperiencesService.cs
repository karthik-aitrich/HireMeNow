using AutoMapper;
using Domain.Models;
using Domain.Services.WorkExperiences.DTO;
using Domain.Services.WorkExperiences.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.WorkExperiences.Service
{
   

    public class WorkExperiencesService : IWorkExperiencesService
    {
        private readonly IWorkExperienceRepository _repository;
        private readonly IMapper _mapper;

        public WorkExperiencesService(
            IWorkExperienceRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }




        public async Task<WorkExperienceDto> AddWorkExperienceAsync(Guid profileId, WorkExperienceDto dto)
        {
            var work = _mapper.Map<WorkExperience>(dto);
            
            work.WorkId = Guid.NewGuid();
            
            work.JobSeekerProfileId = profileId;

            await _repository.AddWorkExperienceAsync(work);
            return _mapper.Map<WorkExperienceDto>(work);
        }




        public async Task<List<WorkExperienceDto>> GetWorkExperienceByProfileIdAsync(Guid id ,Guid profileId)
        {
            var experiences = await _repository.GetWorkExperienceByProfileIdAsync(profileId);

            if (experiences.Any(e => e.JobSeekerProfileId != profileId))
                throw new UnauthorizedAccessException("You cannot edit this experience");


            return _mapper.Map<List<WorkExperienceDto>>(experiences);
        }




       
        public async Task<WorkExperienceDto?> GetWorkExperienceByIdAsync(Guid id , Guid profileId)
        {
            var experience = await _repository.GetWorkExperienceByIdAsync(id);
            
            if (experience == null)
                return null;

            if (experience.JobSeekerProfileId != profileId)
                throw new UnauthorizedAccessException("You cannot edit this experience");


            return _mapper.Map<WorkExperienceDto>(experience);
        }




        public async Task UpdateWorkExperienceAsync(Guid id, Guid profileId, WorkExperienceDto dto)
        {
            var existing = await _repository.GetWorkExperienceByIdAsync(id);

            if (existing == null)
                throw new Exception("Work experience not found");


            if (existing.JobSeekerProfileId != profileId)
                throw new UnauthorizedAccessException("You cannot edit this experience");


            _mapper.Map(dto, existing);


            await _repository.UpdateWorkExperienceAsync(existing);

             _mapper.Map<WorkExperienceDto>(existing);
        }





        public async Task DeleteWorkExperienceAsync(Guid id, Guid profileId)
        {
            var existing = await _repository.GetWorkExperienceByIdAsync(id);

            if (existing == null)
                throw new Exception("Work experience not found");


            if (existing.JobSeekerProfileId != profileId)
                throw new UnauthorizedAccessException("You cannot delete this experience");

            await _repository.DeleteWorkExperienceAsync(id);
        }
    }
}
