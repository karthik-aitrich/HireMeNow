using _Hire_Me_Now_.API.JobPostss.DTO.ResponseObject;
using AutoMapper;
using Domain.Services.JobPosts.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _Hire_Me_Now_.API.JobPostss.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobManagementsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobPostsService _jobPostsService;

        public JobManagementsController(IMapper mapper, IJobPostsService jobPostsService)
        {
            _mapper = mapper;
            _jobPostsService = jobPostsService;
        }

        [HttpPost]
        [Route("GetAllJobs")]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllJobs()
        {
            var job = await _jobPostsService.GetAllJobsAsync();
            var response = _mapper.Map<IEnumerable<JobPostResponseObject>>(job);
            return Ok(new
            {
                message="All Jobs Fetched Successfully",
                data=response
            });

        }
        [HttpPut]
        [Route("ApproveJob/{id}")]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> ApproveJob(Guid id)
        {
            try
            {
                var result = await _jobPostsService.ApproveJobAsync(id);
                //var response = _mapper.Map<JobPostResponseObject>(result);

       

                return Ok(new
                {
                    message = "Job Approved Successfully"
                }
                    //data=response}
                    );
            }catch (Exception ex){ 
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("Reject/{id}")]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> RejectJob(Guid id)
        {
            try
            {
                var result = await _jobPostsService.RejectJobAsync(id);
                //var response = _mapper.Map<JobPostResponseObject>(result);


                return Ok(new
                {
                    message = "Job Rejected Successfully"
                    //,
                    //data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut]
        [Route("Block/{id}")]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> BlockJob(Guid id)
        {
            try
            {
                var result = await _jobPostsService.BlockJobAsync(id);
                //var response = _mapper.Map<JobPostResponseObject>(result);


                return Ok(new
                {
                    message = "Job Blocked Successfully"
                    //,
                    //data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut]
        [Route("Unblock/{id}")]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UnblockJob(Guid id)
        {
            try
            {
                var result = await _jobPostsService.UnblockJobAsync(id);
                //var response = _mapper.Map<JobPostResponseObject>(result);

                return Ok(new
                {
                    message = "Job Unblocked Successfully"
                    //,
                    //data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

