using Domain.Models;
using Domain.Services.JobsApplication.JobProviderApplication.Interface;
using Domain.Services.JobsApplication.JobSeekerApplication.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobsApplication.Repository
{
    public class JobProviderApplicationRepository:IJobProviderApplicationRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public JobProviderApplicationRepository(
            DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.JobApplication>> GetByProviderIdAsync(Guid providerId)
        {
            return await _context.JobApplications
                .Include(a => a.Job)  
                .Where(a => a.Job.PostedBy == providerId)
                .ToListAsync();
        }

        public async Task<Domain.Models.JobApplication?> GetByIdAsync(Guid applicationId)
        {
            return await _context.JobApplications
                .Include(a => a.Job)
                .FirstOrDefaultAsync(a => a.ApplicationId == applicationId);
        }

        public async Task UpdateAsync(Domain.Models.JobApplication application)
        {
            _context.JobApplications.Update(application);
            await _context.SaveChangesAsync();
        }
    }

}

 