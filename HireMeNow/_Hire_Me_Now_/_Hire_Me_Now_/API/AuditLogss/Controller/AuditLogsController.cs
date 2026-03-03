using _Hire_Me_Now_.API.AuditLogss.DTO.AuditLogsRequestObject;
using _Hire_Me_Now_.API.AuditLogss.DTO.AuditLogsResponseObject;
using AutoMapper;
using Domain.Services.AuditLogs.DTO;
using Domain.Services.AuditLogs.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _Hire_Me_Now_.API.AuditLogs.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {
        private readonly IAuditLogsService _auditLogService;
        private readonly IMapper _mapper;

        public AuditLogsController(IAuditLogsService auditLogService, IMapper mapper)
        {
            _auditLogService = auditLogService;
            _mapper = mapper;
        }

        
        [HttpPost]
        [Route("CreateLog")]
        //[Authorize]
        public async Task<IActionResult> CreateLog(AuditLogsRequestObject request)
        {
            var dto = _mapper.Map<AuditLogsDto>(request);

            await _auditLogService.AddLogAsync(dto);

            return Ok(new
            {
                message = "Audit log created successfully"
            });
        }


        [HttpGet]
        [Route("GetAllLogs")]
        //[Authorize]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _auditLogService.GetAllLogsAsync();

            var response = _mapper.Map<IEnumerable<AuditLogsResponseObject>>(logs);

            return Ok(new
            {
                message = "Audit logs fetched successfully",
                data = response
            });
        }


        [HttpGet]
        [Route("GetByUser/{userId}")]
        //[Authorize]
        public async Task<IActionResult> GetByUser(Guid userId)
        {
            var logs = await _auditLogService.GetLogsByUserIdAsync(userId);

            var response = _mapper.Map<IEnumerable<AuditLogsResponseObject>>(logs);

            return Ok(new
            {
                data = response
            });
        }
    }
}