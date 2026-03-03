using _Hire_Me_Now_.API.JobSeekers.DTO.Response;
using Domain.Services.JobSeekers.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _Hire_Me_Now_.API.JobSeekers.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerJobController : ControllerBase
    {
        private readonly IJobSeekerJobService _service;

        public JobSeekerJobController(
            IJobSeekerJobService service)
        {
            _service = service;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _service.GetJobsAsync();

            var response = jobs.Select(j => new JobSeekerJobResponse
            {
                JobId = j.JobId,
                JobTitle = j.JobTitle,
                JobSummary = j.JobSummary,
                ProviderId = j.ProviderId,
                PostedDate = j.PostedDate
            });

            return Ok(response);
        }

        // GET JOB BY ID
        [HttpGet("{jobId}")]
        public async Task<IActionResult> GetJobById(Guid jobId)
        {
            var job = await _service.GetJobByIdAsync(jobId);

            if (job == null)
                return NotFound();

            var response = new JobSeekerJobResponse
            {
                JobId = job.JobId,
                JobTitle = job.JobTitle,
                JobSummary = job.JobSummary,
                ProviderId = job.ProviderId,
                PostedDate = job.PostedDate
            };

            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchJobs(
    [FromQuery] string? keyword,
    [FromQuery] Guid? locationId,
    [FromQuery] Guid? categoryId)
        {
            var jobs = await _service.SearchJobsAsync(
                keyword,
                locationId,
                categoryId);

            var response = jobs.Select(j => new JobSeekerJobResponse
            {
                JobId = j.Id,
                JobTitle = j.JobTitle,
                JobSummary = j.JobSummary,
                PostedDate = j.PostedDate
            });

            return Ok(response);
        }
    }
}
