using _Hire_Me_Now_.API.JobPostss.DTO.ResponseObject;
using _Hire_Me_Now_.API.Locationss.DTO.RequestObject;
using _Hire_Me_Now_.API.Locationss.DTO.ResponseObject;
using AutoMapper;
using Domain.Services.Locations.DTO;
using Domain.Services.Locations.Interface;
using Domain.Services.Locations.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _Hire_Me_Now_.API.Locationss.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsService _locationsService;
        private readonly IMapper _mapper;

        public LocationsController(ILocationsService locationsService, IMapper mapper)
        {
            _locationsService = locationsService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateLocation")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateLocation(LocationRequestObject locationRequest)
        {
            var location = _mapper.Map<LocationsDto>(locationRequest);

            var result=await _locationsService.AddLocationAsync(location);

            var response= _mapper.Map<LocationResponseObject>(result);

            return Ok(new
            {
                message="Location Added Successfully",
                data=response
            });
        }

        [HttpGet]
        [Route("GetAllLocations")]
        public async Task<IActionResult> GetAllLocations()
        {
            var location = await _locationsService.GetAllLocationsAsync();

          
            var response = _mapper.Map<IEnumerable<LocationResponseObject>>(location);

            return Ok(new
            {
                message="All Locations Fetched Successfully",
                data=response
            });
        }

        [HttpGet]
        [Route("GetLocationById/{id}")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetLocationById(Guid id)
        {
            try
            {
                var location = await _locationsService.GetLocationByIdAsync(id);

                if (location == null)
                {
                    return null;
                }
                var response = _mapper.Map<LocationResponseObject>(location);

                return Ok(new
                {
                    message = "Job Fetched Successfully",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                    
            }
        }

        [HttpPut]
        [Route("UpdateLocation/{id}")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateLocation(Guid id,LocationRequestObject locationRequest)
        {
            try
            {
                var location = _mapper.Map<LocationsDto>(locationRequest);

                var response = await _locationsService.UpdateLocationAsync(id, location);

                if (!response)
                    return NotFound();

                return Ok(new
                {
                    message = "Location Updated Successfully",
                    data = response
                });
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete]
        [Route("DeleteLocation/{id}")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteLocation(Guid id)
        {
            try
            {
                var response = await _locationsService.DeleteLocationAsync(id);

                if (!response)
                {
                    return NotFound();
                }

                return Ok(new
                {
                    message = "Location Deleted Successfully",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchingLocations")]
        public async Task<IActionResult> Search(string keyword)
        {


            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.ToLower();

            var jobs=await _locationsService.GetAllLocationsAsync();

            var filtered = jobs.Where(j => j.Name.ToLower().Contains(keyword)).ToList();

            var response = _mapper.Map<List<LocationResponseObject>>(filtered);

            return Ok(new
            {
                data = response
            });
        }
    }
}
