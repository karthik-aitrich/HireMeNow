using _Hire_Me_Now_.API.JobPostss.DTO.ResponseObject;
using _Hire_Me_Now_.API.SystemUserss.DTO.ResponseObject;
using AutoMapper;
using Domain.Models;
using Domain.Services.SystemUsers.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _Hire_Me_Now_.API.SystemUserss.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUsersManagement : ControllerBase
    {
        private readonly ISystemUsersService _systemUsersService;
        private readonly IMapper _mapper;

        public SystemUsersManagement(ISystemUsersService systemUsersService, IMapper mapper)
        {
            _systemUsersService = systemUsersService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _systemUsersService.GetAllUsersAsync();
                var response = _mapper.Map<IEnumerable<SystemUserResponseObject>>(users);

                return Ok(new
                {
                    message = "All Users Fetched Successfully",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await _systemUsersService.GetUserByIdAsync(id);
                var response = _mapper.Map<SystemUserResponseObject>(user);

                return Ok(new
                {
                    message = "User Fetched Successfully",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("BlockUser")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> BlockUser(Guid id)
        {
            try
            {
                await _systemUsersService.BlockUserAsync(id);
                return Ok(new
                {
                    message="User Blocked Successfully"
                });
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut]
        [Route("UnblockUser")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> UblockUser(Guid id)
        {
            try
            {
                await _systemUsersService.UnblockUserAsync(id);
                return Ok(new
                {
                    message = "User Unblocked Successfully"
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchingSystemUser")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.ToLower();

            var users=await _systemUsersService.GetAllUsersAsync();
            var filtered = users.Where(u => u.UserName.ToLower().Contains(keyword)
            || u.FirstName.ToLower().Contains(keyword)
            || u.Email.ToLower().Contains(keyword)
            ||u.Role.ToString().Contains(keyword)
            ).ToList();

            var response=_mapper.Map<IEnumerable<SystemUserResponseObject>>(filtered);

            return Ok(new
            {
                message="Filtered Successfully",
                data=response 
            });
        }

      
    }
}
