using _Hire_Me_Now_.API.WorkExperiencess.Dto.RequestObject;
using _Hire_Me_Now_.API.WorkExperiencess.Dto.ResponseObject;
using AutoMapper;
using Domain.Services.WorkExperiences.DTO;
using Domain.Services.WorkExperiences.Interface;
using Domain.Services.WorkExperiences.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _Hire_Me_Now_.API.WorkExperiencess.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceController : ControllerBase
    {
        private readonly IWorkExperiencesService _service;
        private readonly IMapper _mapper;


        public WorkExperienceController(IWorkExperiencesService service , IMapper mapper)
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


     


        [HttpPost("AddWorkExperience")]
        //[Authorize("Role = SEEKER")]

        public async Task <IActionResult>AddExperience(Guid SeekerId , ExperienceRequest request )
        {
            //var userId = GetUserId();

            var userId = TestUserID();

            

            var experience = _mapper.Map<WorkExperienceDto>(request);

            var result = await _service.AddWorkExperienceAsync(userId, experience);

            var response = _mapper.Map<ExperienceResponse>(result);

            return Ok(response);
        }



        [HttpGet("GetExperiencesByProfileId")]
        //[Authorize("Role = SEEKER")]

        public async Task <IActionResult>GetExperienceByProfileId(Guid SeekerId)
        {
            //var userId = GetUserId();

            var userId = TestUserID();

            var experience = await _service.GetWorkExperienceByProfileIdAsync(userId , SeekerId);

            var result = _mapper.Map<List<ExperienceResponse>>(experience);

            return Ok(result);

        }



        //[HttpGet("GetExperienceById")]
        ////[Authorize("Role = SEEKER")]

        //public async Task <IActionResult> GetExperienceById(Guid profileId)
        //{
        //    //var UserId = GetUserId();

        //    var userId = TestUserID();

        //    var experience = await _service.GetWorkExperienceByIdAsync(userId, profileId);

        //    var result = _mapper.Map<WorkExperienceDto>(experience);

        //    return Ok(result);
        //}



        [HttpPut("UpdateExperience")]
        //[Authorize("Role = SEEKER")]

        public async Task <IActionResult>UpdateExperience( Guid SeekerId ,Guid id, ExperienceRequest request)
        {
            //var userId = GetUserId();

            var userId = TestUserID();

            var experience = _mapper.Map<WorkExperienceDto>(request);

           await _service.UpdateWorkExperienceAsync(id, userId, experience);

          
            return Ok( "updated successfully ");

        }



        [HttpDelete("DeleteExperience")]
        //[Authorize("Role = SEEKER")]

        public async Task <IActionResult>DeleteExperience(Guid SeekerId , Guid id)
        {
            //var userId = GetUserId();

            var userId = TestUserID();

            await _service.DeleteWorkExperienceAsync(id, userId);

            return Ok("Deleted Successfully ");
        }


    }
}
