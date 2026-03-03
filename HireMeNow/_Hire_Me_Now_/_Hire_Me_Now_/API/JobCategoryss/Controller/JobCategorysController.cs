using _Hire_Me_Now_.API.JobCategoryss.DTO.RequestObject;
using _Hire_Me_Now_.API.JobCategoryss.DTO.ResponseObject;
using _Hire_Me_Now_.API.Locationss.DTO.RequestObject;
using _Hire_Me_Now_.API.Locationss.DTO.ResponseObject;
using AutoMapper;
using Domain.Services.JobCategorys.DTO;
using Domain.Services.JobCategorys.Interface;
using Domain.Services.Locations.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _Hire_Me_Now_.API.JobCategoryss.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategorysController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobCategoriesService _jobCategoriesService;

        public JobCategorysController(IMapper mapper, IJobCategoriesService jobCategoriesService)
        {
            _mapper = mapper;
            _jobCategoriesService = jobCategoriesService;
        }
   
        [HttpPost]
        [Route("CreateJobCategory")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateJobCategory(JobCategoryRequestObject jobCategoryRequest)
        {
            var jobCategory=_mapper.Map<JobCategorysDto>(jobCategoryRequest);

            var result = await _jobCategoriesService.AddJobCategoryAsync(jobCategory);

            var response = _mapper.Map<JobCategoryResponseObject>(result);

            return Ok(new
            {
                message="JobCategory Added Successfully",
                data=response
            });
        }

        [HttpGet]
        [Route("GetAllJobCategories")]
        public async Task<IActionResult> GetAllJobCategories()
        {
            var jobCategory=await _jobCategoriesService.GeAlltJobCategoriesAsync();

            var response = _mapper.Map<IEnumerable<JobCategoryResponseObject>>(jobCategory);

            return Ok(new
            {
                message="All Job Categories Fetched Successfully",
                data=response   
            });
        }


        [HttpGet]
        [Route("GetJobCategoryById/{id}")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetJobCategoryById(Guid id)
        {
            try
            {
                var jobCategory = await _jobCategoriesService.GetJobCategoryByIdAsync(id);

                if (jobCategory == null)
                {
                    return null;
                }

                var response = _mapper.Map<JobCategoryResponseObject>(jobCategory);

                return Ok(new
                {
                    message = "Job Category Fetched Successfully",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);    
            }
        }

        [HttpPut]
        [Route("UpdateJobCategory/{id}")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateJobCategory(Guid id, JobCategoryRequestObject jobCategoryRequest)
        {
            try
            {
                var jobCategory = _mapper.Map<JobCategorysDto>(jobCategoryRequest);

                var response = await _jobCategoriesService.UpdateJobCategoryAsync(id, jobCategory);
                if (!response)
                    return NotFound();

                return Ok(new
                {
                    message = "Job Category Updated Successfully",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteJobCategory/{id}")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteJobCategory(Guid id)
        {
            try
            {
                var response = await _jobCategoriesService.DeleteJobCategoryAsync(id);

                if (!response)
                    return NotFound();

                return Ok(new
                {
                    message="Job Category Deleted Successfully",
                    data = response
                });
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
