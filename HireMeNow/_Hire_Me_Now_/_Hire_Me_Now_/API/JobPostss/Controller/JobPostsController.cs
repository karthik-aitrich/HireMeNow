using _Hire_Me_Now_.API.JobPostss.DTO.RequestObject;
using _Hire_Me_Now_.API.JobPostss.DTO.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.JobPosts.DTO;
using Domain.Services.JobPosts.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _Hire_Me_Now_.API.JobPostss.Controller
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostsController : ControllerBase
    {
        private readonly IJobPostsService _jobPostsService;
        private readonly IMapper _mapper;

        public JobPostsController(IJobPostsService jobPostsService, IMapper mapper)
        {
            _jobPostsService = jobPostsService;
            _mapper = mapper;
        }

        //private Guid GetUserId()
        //{
        //    var claim = User.FindFirst(ClaimTypes.NameIdentifier);

        //    if (claim == null)
        //        throw new UnauthorizedAccessException("User ID claim not found.");

        //    return Guid.Parse(claim.Value);
        //}

        private Guid TestUserId()//just for checking
        {
            return Guid.Parse("84BA2425-8056-43ED-B92B-5672AEA5922A");

        }   

        [HttpPost]
        [Route("CreateJob")]
        public async Task<IActionResult> CreateJob(JobPostsRequestObject jobPostsRequest)
        {
            //var userId = GetUserId();

            var userId=TestUserId();        //just for checking

            var job = _mapper.Map<JobPostsDto>(jobPostsRequest);

            if (jobPostsRequest.Responsibilities != null)
            {
                job.Responsibilities =
                    _mapper.Map<List<JobResponsibilityDto>>(jobPostsRequest.Responsibilities);
            }

            var result = await _jobPostsService.CreateJobAsync(job, userId);

            var response = _mapper.Map<JobPostResponseObject>(result);

            return Ok(new
            {
                message = "Job Created Successfully",
                data = response
            });
        }


        [HttpGet]
        [Route("GetJobById/{id}")]
        public async Task<IActionResult> GetJobById(Guid id)
        {
            //var userId = GetUserId();
            var userId = TestUserId();        //just for checking

            var job = await _jobPostsService.GetJobByIdAsync(id, userId);

            if (job == null)
                return NotFound();

            var response = _mapper.Map<JobPostResponseObject>(job);

            return Ok(new
            {
                data = response
            });
        }

   
        [HttpGet]
        [Route("GetMyJobs")]
        public async Task<IActionResult> GetMyJobs()
        {
            //var userId = GetUserId();
            var userId = TestUserId();        //just for checking

            var jobs = await _jobPostsService.GetMyJobsAsync(userId);

            var response = _mapper.Map<List<JobPostResponseObject>>(jobs);

            return Ok(new
            {
                data = response
            });
        }


        [HttpPut]
        [Route("UpdateJob/{id}")]
        public async Task<IActionResult> UpdateJob(Guid id, JobPostsRequestObject jobPostsRequest)
        {
            //var userId = GetUserId();
            var userId = TestUserId();        //just for checking

            var job = _mapper.Map<JobPostsDto>(jobPostsRequest);

            var success = await _jobPostsService.UpdateJobAsync(id, job, userId);

            if (!success)
                return Forbid();

            return Ok(new
            {
                message = "Job Updated Successfully"
            });
        }

        [HttpDelete]
        [Route("DeleteJob/{id}")]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            //var userId = GetUserId();
            var userId = TestUserId();        //just for checking

            var success = await _jobPostsService.DeleteJobAsync(id, userId);

            if (!success)
                return Forbid();

            return Ok(new
            {
                message = "Job Deleted Successfully"
            });
        }

    
   
        [HttpGet]
        [Route("SearchingJobs")]
        public async Task<IActionResult> Search(string keyword)
        {
            //var userId = GetUserId();
            var userId = TestUserId();        //just for checking

            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.ToLower();

            var jobs = await _jobPostsService.GetMyJobsAsync(userId);

            var filtered = jobs.Where(j =>
                   j.JobTitle.ToLower().Contains(keyword)
                || j.JobSummary.ToLower().Contains(keyword)
                || j.JobMode.ToString().ToLower().Contains(keyword)
                || j.JobType.ToString().ToLower().Contains(keyword)
            ).ToList();

            var response = _mapper.Map<List<JobPostResponseObject>>(filtered);

            return Ok(new
            {
                data = response
            });
        }
    }
}