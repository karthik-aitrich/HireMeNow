using _Hire_Me_Now_.API.Qualificationss.DTO.RequestObject;
using _Hire_Me_Now_.API.Qualificationss.DTO.ResponseObject;
using AutoMapper;
using Domain.Services.Qualifications.DTO;
using Domain.Services.Qualifications.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _Hire_Me_Now_.API.Qualificationss.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class QualificationController : ControllerBase
    {

        public readonly IQualificationsService _service;
        public readonly IMapper _mapper;

        public QualificationController(IQualificationsService service, IMapper mapper)
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






        [HttpPost("AddQualification")]
        //[Authorize("Role = SEEKER")]

        public async Task<IActionResult> AddQualification(Guid SeekerId, QualificationRequest request)
        {

            var userId = TestUserID();

            var qualification = _mapper.Map<QualificationsDto>(request);

            var result = await _service.AddQualificationAsync(userId, qualification);

            var response = _mapper.Map<QualificationResponse>(result);

            return Ok(response);

        }





        [HttpGet("GetQualifications")]
        //[Authorize("Role = SEEKER")]
        public async Task<IActionResult> GetQualifications(Guid SeekerId)
        {
            var userId = TestUserID();

            var qualifications = await _service.GetQualificationsAsync(userId);

            var result = _mapper.Map<List<QualificationResponse>>(qualifications);

            return Ok(result);
        }




        //[HttpGet("GetQualificationById/{profileId}")]
        ////[Authorize("Role = SEEKER")]
        //public async Task<IActionResult> GetQualificationById(Guid id)
        //{
        //    var userId = TestUserID();

        //    var qualification = await _service.GetQualificationByIdAsync(id, userId);

        //    if (qualification == null)
        //    {
        //        return NotFound("not found");
        //    }

        //    var result = _mapper.Map<QualificationResponse>(qualification);

        //    return Ok(result);
        //}






        [HttpPut("UpdateQualification")]
        //[Authorize("Role = SEEKER")]

        public async Task<IActionResult> UpdateQualification(Guid SeekerId ,Guid id, QualificationRequest request)
        {
            var userId = TestUserID();

            var qualification = _mapper.Map<QualificationsDto>(request);

            await _service.UpdateQualificationAsync(id, userId , qualification);

           


            return Ok("updated successfully");

        }






        [HttpDelete("DeleteQualification")]
        //[Authorize("Role = SEEKER")]

        public async Task <IActionResult> DeleteQualification(Guid SeekerId , Guid id)
        {
            var userId = TestUserID();

           await _service.DeleteQualificationAsync(id, userId);

           

            return Ok("deleted Successfully");
        }

    }

}
