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
    public class JobsSeekerApplicationRepository : IJobSeekerApplicationRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public JobsSeekerApplicationRepository(
            DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.JobApplication>>
            GetBySeekerIdAsync(Guid seekerId)
        {
            return await _context.JobApplications
                .Where(a => a.SeekerId == seekerId)
                .ToListAsync();
        }

        public async Task<Domain.Models.JobApplication?> GetByIdAsync(Guid applicationId)
        {
            return await _context.JobApplications
                .FirstOrDefaultAsync(a => a.ApplicationId == applicationId);
        }

        public async Task AddAsync(Domain.Models.JobApplication application)
        {
            await _context.JobApplications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Models.JobApplication application)
        {
            _context.JobApplications.Update(application);
            await _context.SaveChangesAsync();
        }
    }

}

