using _Hire_Me_Now_.API.AdminDashboardss.Dto.ResponseObject;
using AutoMapper;
using Domain.Services.AdminDashboards.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _Hire_Me_Now_.API.AdminDashboardss.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardsController : ControllerBase
    {
        private readonly IAdminDashboardService _adminDashboardService;
        private readonly IMapper _mapper;

        public AdminDashboardsController(IAdminDashboardService adminDashboardService, IMapper mapper)
        {
            _adminDashboardService = adminDashboardService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAdminDashboard")]
        //[Authorize(Roles="Admin")]
        public async Task<IActionResult> GetAdminDashboard()
        {
            var dashboard = await _adminDashboardService.GetDashboardsDataAsync();
            var response=_mapper.Map<AdminDashboardResponseObject>(dashboard);

            return Ok(new
            {
                message="Admin Dashboard Fetched Successfully",
                data=response
            });
        }
    }
}
