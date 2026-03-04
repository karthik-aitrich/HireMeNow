using AutoMapper;
using Domain.Services.JobsApplication.JobProviderApplication.Dto;
using Domain.Services.JobsApplication.JobProviderApplication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobApplication.Service
{
    public class JobProviderApplicationService:IJobProviderApplicationService
    {
        private readonly IJobProviderApplicationRepository _repository;
        private readonly IMapper _mapper;

        public JobProviderApplicationService(
            IJobProviderApplicationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<JobProviderApplicationDto>>
            GetApplicationsByProviderIdAsync(Guid providerId)
        {
            var applications =
                await _repository.GetByProviderIdAsync(providerId);

            return _mapper.Map<List<JobProviderApplicationDto>>(applications);
        }

        public async Task<bool> UpdateApplicationStatusAsync(
            ApplyJobDto dto)
        {
            var application =
                await _repository.GetByIdAsync(dto.ApplicationId);

            if (application == null)
                return false;

            if (application.Job == null ||
                application.Job.PostedBy != dto.ProviderId)
                return false;

            application.Status = dto.Status;

            await _repository.UpdateAsync(application);

            return true;
        }
    }
}
