                  using _Hire_Me_Now_.API.JobSeekerApplication.Dto.RequestObjects;
using _Hire_Me_Now_.API.JobSeekerApplication.Dto.ResponseObjetcs;
using AutoMapper;
using Domain.Services.JobsApplication.JobProviderApplication.Dto;
using Domain.Services.JobsApplication.JobSeekerApplication.Dto;
using Domain.Services.JobsApplication.JobSeekerApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _Hire_Me_Now_.API.JobSeekerApplication.Contoller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerApplicationsController : ControllerBase
    {
        private readonly IJobSeekerApplicationService _service;
        private readonly IMapper _mapper;

        public JobSeekerApplicationsController(
            IJobSeekerApplicationService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

     
        [HttpGet("{seekerId}")]
        public async Task<IActionResult> GetApplications(Guid seekerId)
        {
            var result = await _service.GetApplicationsAsync(seekerId);

            var response =
                _mapper.Map<List<JobSeekerApplicationResponse>>(result);

            return Ok(response);
        }

     
        [HttpPost("apply")]
        public async Task<IActionResult> Apply(
            JobSeekerApplyRequest request)
        {
            var dto = new JobSeekerApplicationDto
            {
                JobId = request.JobId,
                SeekerId = request.SeekerId,
                ResumeId = request.ResumeId,
                CoverLetter = request.CoverLetter
            };

            await _service.ApplyAsync(dto);

            return Ok("Application Submitted");
        }

      
        [HttpPut("withdraw")]
        public async Task<IActionResult> Withdraw(
            JobSeekerWithdrawRequest request)
        {
            var dto = new JobSeekerWithdrawApplicationDto
            {
                ApplicationId = request.ApplicationId,
                SeekerId = request.SeekerId
            };

            var success = await _service.WithdrawAsync(dto);

            if (!success)
                return BadRequest("Cannot withdraw");

            return Ok("Application Withdrawn");
        }
    }
}
