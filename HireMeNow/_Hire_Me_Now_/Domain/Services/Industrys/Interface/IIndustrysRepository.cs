using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Industrys.Interface
{
    public interface IIndustrysRepository
    {
        Task<Industry> AddIndustryAsync(Industry industry);
        Task<IEnumerable<Industry>> GetAllIndustrysAsync();
        Task<Industry?> GetIndustryByIdAsync(Guid id);
        Task UpdateIndustryAsync(Industry industry);
        Task DeleteIndustryAsync(Guid id);
    }
}
