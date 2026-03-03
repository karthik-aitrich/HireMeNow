using _Hire_Me_Now_.API.Resumess.DTO.RequestObject;
using _Hire_Me_Now_.API.Resumess.DTO.ResponseObject;
using AutoMapper;
using Domain.Services.Resumes.DTO;
using Domain.Services.Resumes.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _Hire_Me_Now_.API.Resumess.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {

        private readonly IResumesService _service;
        private readonly IMapper _mapper;



        public ResumeController (IResumesService service , IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        //[NonAction]
        //public Guid GetUserId()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    if (string.IsNullOrEmpty(userId))
        //        throw new UnauthorizedAccessException("Invalid token");

        //    return Guid.Parse(userId);
        //}




        private Guid TestUserID()
        {
            return Guid.Parse("96e38370-2913-4d96-8eaf-dca788c66308");   // seekerprofileId
        }




        [HttpPost("AddResume")]
        //[Authorize("Role = SEEKER")]
        public async Task <IActionResult>AddResume(Guid SeekerId , [FromForm] ResumeRequest request )
        {
            var userId = TestUserID();

            var resume = _mapper.Map<ResumesDto>(request);

            resume.UploadedAt = DateTime.UtcNow;

            var result = await _service.CreateResumeAsync(userId, resume);

            var response = _mapper.Map<ResumeResponse>(result);

            return Ok("Added");
        }



        [HttpGet("GetMyResume")]
        //[Authorize("Role = SEEKER")]
        public async Task <IActionResult>GetMyResume(Guid SeekerId)
        {

            var UserId = TestUserID();

            var resume = await _service.GetMyResumeAsync(UserId);

            var result = _mapper.Map<List<ResumeResponse>>(resume);

            return Ok(result);

        }



        [HttpPut("UpdateResume")]
        //[Authorize("Role = SEEKER")]
        public async Task <IActionResult> UpdateResume(Guid SeekerId , Guid id , ResumeRequest request)
        {
            var userId = TestUserID();

            var resume = _mapper.Map<ResumesDto>(request);

            var result = await _service.UpdateResumeAsync(id, userId, resume);

            if (result == null)
            {
                return NotFound("not found");
            }

            var response = _mapper.Map<ResumeResponse>(result);


            return Ok(response);

        }



        [HttpDelete("DeleteResume")]
        //[Authorize("Role = SEEKER")]
        public async Task <IActionResult> DeleteResume(Guid SeekerId , Guid id)
        {
            var userId = TestUserID();

            await _service.DeleteResumeAsync( id , userId );


            return Ok("Deleted Successfully");

        }



        [HttpGet("GetAllResumes")]
        //[Authorize("Role = ADMIN")]

        public async Task <IActionResult>GetAllResume()
        {
            var resume = await _service.GetAllResumeAsync();

            var result = _mapper.Map<List<ResumeResponse>>(resume);

            return Ok(result);
        }

    }
}
