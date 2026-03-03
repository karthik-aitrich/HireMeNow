using _Hire_Me_Now_.API.Interviews.Dto.RequestObject;
using _Hire_Me_Now_.API.Interviews.Dto.ResponseObject;
using AutoMapper;
using Domain.Services.Interviews.Dto;
using Domain.Services.Interviews.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class InterviewController : ControllerBase
{

    private readonly IInterviewService _service;
    private readonly IMapper _mapper;


    public InterviewController(IInterviewService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }




    private Guid TestUserID()
    {
        return Guid.Parse("06254D52-69BB-43C2-A1A2-F003F6116F83");  //systemUserId / jobProviderId
    }


    //   06254D52-69BB-43C2-A1A2-F003F6116F83



    [HttpPost("AddInterview")]
    public async Task<IActionResult> AddInterview(Guid providerId, [FromBody] InterviewRequest request)
    {

        var proId = TestUserID();

        var dto = _mapper.Map<InterviewDto>(request);

        var result = await _service.ScheduleInterviewAsync(proId, dto);

      


        return Ok(result);
    }

 


    [HttpGet("GetInterviews")]
    public async Task<IActionResult> GetMyInterviews(Guid providerId)
    {

        var proId = TestUserID();

        var result = await _service.GetMyInterviewsAsync(proId);

        var response = _mapper.Map<List<InterviewResponse>>(result);

        return Ok(response);
    }






    [HttpPut("UpdateInterview")]
    public async Task<IActionResult> UpdateInterview(Guid providerId, Guid id, [FromBody] InterviewRequest request)
    {
        var dto = _mapper.Map<InterviewDto>(request);

        var updated = await _service.UpdateInterviewAsync(id, providerId, dto);

        return Ok(updated);
    }

   


    [HttpDelete("DeleteInterview")]
    public async Task<IActionResult> Delete(Guid providerId, Guid id)
    {
        await _service.DeleteInterviewAsync(id, providerId);

        return Ok("Interview deleted successfully");
    }




    [HttpGet("GetAllInterview")]
    //[Authorize("Role = ADMIN")]

    public async Task <IActionResult>GetAllInterview()
    {
        var interview = await _service.GetAllInterviewAsync();

        return Ok(interview);
    }






    [HttpGet("GetInterviewById")]
    public async Task<IActionResult> GetInterviewById(Guid providerId, Guid id)
    {
        var result = await _service.GetInterviewByIdAsync(id, providerId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }








}