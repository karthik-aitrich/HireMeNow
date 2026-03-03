using AutoMapper;
using Domain.Models;
using Domain.Services.Qualifications.DTO;
using Domain.Services.Qualifications.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Qualifications.Service
{
    public class QualificationsService : IQualificationsService
    {
        private readonly IQualificationsRepository _repo;
        private readonly IMapper _mapper;

        public QualificationsService(IQualificationsRepository repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<QualificationsDto> AddQualificationAsync(Guid jobSeekerId, QualificationsDto dto)
        {
            var qualification = _mapper.Map<Qualification>(dto);

            qualification.Id = Guid.NewGuid(); 
            qualification.JobSeekerProfileId = jobSeekerId;

            await _repo.AddQualificationAsync(qualification);

            return _mapper.Map<QualificationsDto>(qualification);
        }


        public async Task<List<QualificationsDto>> GetQualificationsAsync(Guid jobSeekerId)
        {
            var qualifications = await _repo.GetByJobSeekerIdAsync(jobSeekerId);

            return _mapper.Map<List<QualificationsDto>>(qualifications);
        }


        public async Task<QualificationsDto?> GetQualificationByIdAsync(Guid qualificationId, Guid jobSeekerId)
        {
            var qualification = await _repo.GetQualificationByIdAsync(qualificationId);

            if (qualification == null)
                return null;

            if (qualification.JobSeekerProfileId != jobSeekerId)
                throw new UnauthorizedAccessException("You are not allowed to access this qualification");

            return _mapper.Map<QualificationsDto>(qualification);

        }


        public async Task UpdateQualificationAsync(Guid qualificationId, Guid jobSeekerId, QualificationsDto dto)
        {
            var qualification = await _repo.GetQualificationByIdAsync(qualificationId);

            if (qualification == null)
                throw new Exception("Qualification not found");

            if (qualification.JobSeekerProfileId != jobSeekerId)
                throw new UnauthorizedAccessException("You cannot modify this qualification");

            _mapper.Map(dto, qualification);

            await _repo.UpdateQualificationAsync(qualification);
        }


    
        public async Task DeleteQualificationAsync(Guid qualificationId, Guid jobSeekerId)
        {
            var qualification = await _repo.GetQualificationByIdAsync(qualificationId);

            if (qualification == null)
                throw new Exception("Qualification not found");


            if (qualification.JobSeekerProfileId != jobSeekerId)
                throw new UnauthorizedAccessException("You cannot modify this qualification");


            await _repo.DeleteQualificationAsync(qualification);

        }


    }
}
