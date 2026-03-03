using Domain.Models;
using Domain.Services.Industrys.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Industrys.Repository
{
    public class IndustrysRepository:IIndustrysRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public IndustrysRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<Industry> AddIndustryAsync(Industry industry)
        {
            _context.Industries.Add(industry);
            await _context.SaveChangesAsync();
            return industry;
        }

        public async Task<IEnumerable<Industry>> GetAllIndustrysAsync()
        {
            var industries = await _context.Industries.ToListAsync();
            return industries;
        }

        public async Task<Industry?> GetIndustryByIdAsync(Guid id)
        {
            var industry=await _context.Industries.FirstOrDefaultAsync(x => x.Id == id);
            return industry;
        }

        public async Task UpdateIndustryAsync(Industry industry)
        {
           _context.Industries.Update(industry);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteIndustryAsync(Guid id)
        {
            var industry = await _context.Industries.FirstOrDefaultAsync(x => x.Id == id);

            if(industry != null)
            {
                _context.Industries.Remove(industry);
                await _context.SaveChangesAsync();
            }

        }
    }
}
