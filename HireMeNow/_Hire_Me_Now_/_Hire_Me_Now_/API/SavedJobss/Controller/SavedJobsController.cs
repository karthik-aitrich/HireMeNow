using _Hire_Me_Now_.API.SavedJobss.Dto.RequestObject;
using _Hire_Me_Now_.API.SavedJobss.Dto.ResponseObject;
using AutoMapper;
using Domain.Services.SavedJobs.Dto;
using Domain.Services.SavedJobs.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _Hire_Me_Now_.API.SavedJobs.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class SavedJobsController : ControllerBase
    {
        private readonly ISavedJobService _service;
        private readonly IMapper _mapper;

        public SavedJobsController(ISavedJobService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //private Guid GetUserId()
        //{
        //    var claim = User.FindFirst(ClaimTypes.NameIdentifier);

        //    if (claim == null)
        //        throw new UnauthorizedAccessException("User not found");

        //    return Guid.Parse(claim.Value);
        //}
        
        private Guid TestUserId()//just for checking
        {
            return Guid.Parse("ED86D50F-E01F-4FEE-BCAB-F6519BDD5714");

        }   


        [HttpPost]
        [Route("SaveJob")]
        //[Authorize(Roles ="Seeker")]
        public async Task<IActionResult> SaveJob(SavedJobRequestObject request)
        {
            //var userId = GetUserId();
            var userId = TestUserId();

            var dto = _mapper.Map<SavedJobDto>(request);
            dto.systemUserId = userId;

            var result = await _service.SaveJobAsync(dto);

            var response = _mapper.Map<SavedJobResponseObject>(result);

            return Ok(new
            {
                message = "Job Saved Successfully",
                data = response
            });
        }

        [HttpPost]
        [Route("UnsaveJob")]
        //[Authorize(Roles ="Seeker")]`
        public async Task<IActionResult> UnsaveJob(SavedJobRequestObject request)
        {
            //var userId = GetUserId();
            var userId = TestUserId();

            var dto = _mapper.Map<SavedJobDto>(request);
            dto.systemUserId = userId;

            var result = await _service.UnsaveJobAsync(dto);

            var response = _mapper.Map<SavedJobResponseObject>(result);

            return Ok(new
            {
                message = "Job Unsaved Successfully",
                data = response
            });
        }

        [HttpGet]
        [Route("MySavedJobs")]
        //[Authorize(Roles ="Seeker")]
        public async Task<IActionResult> GetMySavedJobs()
        {
            //var userId = GetUserId();
            var userId = TestUserId();

            var result = await _service.GetMySavedJobsAsync(userId);

            var response = _mapper.Map<IEnumerable<SavedJobResponseObject>>(result);

            return Ok(new
            {
                message = "Saved Jobs Fetched Successfully",
                data = response
            });
        }


        [HttpGet]
        [Route("GetSavedJobById/{id}")]
        //[Authorize(Roles ="Seeker")]
        public async Task<IActionResult> GetSavedJobById(Guid id)
        {
            //var userId = GetUserId();
            var userId = TestUserId();

            var result = await _service.GetSavedJobByIdAsync(id, userId);

            if (result == null)
                return NotFound();

            var response = _mapper.Map<SavedJobResponseObject>(result);

            return Ok(new
            {
                data = response
            });
        }
    }
}