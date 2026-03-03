using Domain.Services.Industrys.DTO;
using Domain.Services.Locations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Industrys.Interface
{
    public interface IIndustrysService
    {
        Task<IndustrysDto> AddIndustryAsync(IndustrysDto industrysDto);
        Task<IEnumerable<IndustrysDto>> GetAllIndustrysAsync();
        Task<IndustrysDto?> GetIndustryByIdAsync(Guid id);
        Task<bool> UpdateIndustryAsync(Guid id, IndustrysDto industrysDto);
        Task<bool> DeleteIndustryAsync(Guid id);
    }
}
