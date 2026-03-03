using AutoMapper;
using Domain.Enums;
using Domain.Services.JobsApplication.JobProviderApplication.Dto;
using Domain.Services.JobsApplication.JobSeekerApplication.Dto;
using Domain.Services.JobsApplication.JobSeekerApplication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobsApplication.JobSeekerApplication.Service
{
    public class JobSeekerApplicationService:IJobSeekerApplicationService
    {
        private readonly IJobSeekerApplicationRepository _repository;
        private readonly IMapper _mapper;

        public JobSeekerApplicationService(
            IJobSeekerApplicationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<JobSeekerApplicationDto>>
            GetApplicationsAsync(Guid seekerId)
        {
            var applications =
                await _repository.GetBySeekerIdAsync(seekerId);

            return _mapper.Map<List<JobSeekerApplicationDto>>(applications);
        }

        public async Task<bool> ApplyAsync(JobSeekerApplicationDto dto)
        {
            var entity = _mapper.Map<Domain.Models.JobApplication>(dto);

            entity.ApplicationId = Guid.NewGuid();
            entity.AppliedDate = DateTime.UtcNow;
            entity.Status = ApplicationStatus.Applied;

            await _repository.AddAsync(entity);

            return true;
        }

        public async Task<bool> WithdrawAsync(
            JobSeekerWithdrawApplicationDto dto)
        {
            var application =
                await _repository.GetByIdAsync(dto.ApplicationId);

            if (application == null)
                return false;

            if (application.SeekerId != dto.SeekerId)
                return false;

            application.Status = ApplicationStatus.Withdrawn;

            await _repository.UpdateAsync(application);

            return true;
        }
    }
}
