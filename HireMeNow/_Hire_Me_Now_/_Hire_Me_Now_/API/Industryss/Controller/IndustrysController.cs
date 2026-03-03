using _Hire_Me_Now_.API.Industryss.DTO.RequestObject;
using _Hire_Me_Now_.API.Industryss.DTO.ResponseObject;
using _Hire_Me_Now_.API.Locationss.DTO.RequestObject;
using _Hire_Me_Now_.API.Locationss.DTO.ResponseObject;
using AutoMapper;
using Domain.Services.Industrys.DTO;
using Domain.Services.Industrys.Interface;
using Domain.Services.Locations.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _Hire_Me_Now_.API.Industryss.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustrysController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIndustrysService _industryService;

        public IndustrysController(IMapper mapper, IIndustrysService industryService)
        {
            _mapper = mapper;
            _industryService = industryService;
        }

        [HttpPost]
        [Route("CreateIndustry")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateIndustry(IndustryRequestObject industryRequest)
        {
            var industry = _mapper.Map<IndustrysDto>(industryRequest);

            var result = await _industryService.AddIndustryAsync(industry);
            var response = _mapper.Map<IndustryResponseObject>(result);


            return Ok(new
            {
                message = "Industry Added Successfully",
                data = response
            });
        }

        [HttpGet]
        [Route("GetAllIndustries")]
        public async Task<IActionResult> GetAllIndustrys()
        {
            var industry = await _industryService.GetAllIndustrysAsync();


            var response = _mapper.Map<IEnumerable<IndustryResponseObject>>(industry);

            return Ok(new
            {
                message = "All Industries Fetched Successfully",
                data = response
            });
        }

        [HttpGet]
        [Route("GetIndustryById/{id}")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetIndustryById(Guid id)
        {
            try
            {
                var industry = await _industryService.GetIndustryByIdAsync(id);

                if (industry == null)
                {
                    return null;
                }
                var response = _mapper.Map<IndustryResponseObject>(industry);

                return Ok(new
                {
                    message = "Industry Fetched Successfully",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpPut]
        [Route("UpdateIndustry/{id}")]
        public async Task<IActionResult> UpdateIndustry(Guid id, IndustryRequestObject industryRequest)
        {
            try
            {
                var industry = _mapper.Map<IndustrysDto>(industryRequest);

                var response = await _industryService.UpdateIndustryAsync(id,industry);

                if (!response)
                    return NotFound();

                return Ok(new
                {
                    message = "Industry Updated Successfully",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }


        [HttpDelete]
        [Route("DeleteIndustry/{id}")]
        public async Task<IActionResult> DeleteIndustry(Guid id)
        {
            try
            {
                var response = await _industryService.DeleteIndustryAsync(id);

                if (!response)
                {
                    return NotFound();
                }

                return Ok(new
                {
                    message = "Industry Deleted Successfully",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchingIndustrys")]
        public async Task<IActionResult> Search(string keyword)
        {


            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.ToLower();

            var industry = await _industryService.GetAllIndustrysAsync();

            var filtered = industry.Where(j => j.Name.ToLower().Contains(keyword)).ToList();

            var response = _mapper.Map<List<LocationResponseObject>>(filtered);

            return Ok(new
            {
                data = response
            });
        }
    }
}
