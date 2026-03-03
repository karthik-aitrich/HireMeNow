using Domain.Models;
using Domain.Services.JobCategorys.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobCategorys.Repository
{
    public class JobCategoriesRepository:IJobCategoriesRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public JobCategoriesRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<JobCategory> AddJobCategoryAsync(JobCategory jobCategory)
        {
            await _context.JobCategories.AddAsync(jobCategory);
            await _context.SaveChangesAsync();
            return jobCategory;
        }

        public async Task<IEnumerable<JobCategory>> GetAllJobCategoriesAsync()
        {
            var jobCategory = await _context.JobCategories.ToListAsync();
            return jobCategory;
        }

        public async Task<JobCategory?> GetJobCategoryByIdAsync(Guid id)
        {
            var jobCategory=await _context.JobCategories.FirstOrDefaultAsync(i=>i.Id==id);
            return jobCategory;
        }

        public async Task UpdateJobCategoryAsync(JobCategory jobCategory)
        {
            _context.JobCategories.Update(jobCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobCategoryAsync(Guid id)
        {
            var jobCategory=await _context.JobCategories.FirstOrDefaultAsync(i=>i.Id== id); 

            if(jobCategory!=null)
            {
                _context.JobCategories.Remove(jobCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
