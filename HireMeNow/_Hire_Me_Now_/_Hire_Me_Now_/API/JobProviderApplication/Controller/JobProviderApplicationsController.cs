using AutoMapper;
using Domain.Services.JobsApplication.JobProviderApplication.Dto;
using Domain.Services.JobsApplication.JobProviderApplication.Interface;
using Hire_Me_Now.API.JobProviderApplication.Dto.RequestObject;
using Hire_Me_Now.API.JobProviderApplication.Dto.ResponseObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Hire_Me_Now.API.JobProviderApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobProviderApplicationsController : ControllerBase
    {
        private readonly IJobProviderApplicationService _service;
        private readonly IMapper _mapper;



        public JobProviderApplicationsController(
            IJobProviderApplicationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }


       


        [HttpGet("{providerId}")]
        public async Task<IActionResult> GetApplications(Guid providerId)
        {

            var result =
        await _service.GetApplicationsByProviderIdAsync(providerId);

            var response =
                _mapper.Map<List<JobProviderApplicationResponse>>(result);

            return Ok(response);
        }

        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus(
            JobProviderApplicationStatusRequest request)
        {
            var dto = _mapper.Map<ApplyJobDto>(request);

            var success =
                await _service.UpdateApplicationStatusAsync(dto);

            if (!success)
                return BadRequest("Unauthorized or not found");

            return Ok("Status Updated");


        }
    }
}
