using Domain.Models;
using Domain.Services.WorkExperiences.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.WorkExperiences.Repository
{

    public class WorkExperiencesRepository : IWorkExperienceRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public WorkExperiencesRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }



        public async Task <WorkExperience>AddWorkExperienceAsync(WorkExperience experience)
        {
            await _context.WorkExperiences.AddAsync(experience);

            await _context.SaveChangesAsync();

            return experience;
        }



        public async Task<List<WorkExperience>> GetWorkExperienceByProfileIdAsync(Guid profileId)
        {
            return await _context.WorkExperiences.Where(x => x.JobSeekerProfileId == profileId).ToListAsync();
        }



        public async Task<WorkExperience?> GetWorkExperienceByIdAsync(Guid id)
        {
            return await _context.WorkExperiences.FirstOrDefaultAsync(x => x.WorkId == id);
        }



        public async Task UpdateWorkExperienceAsync(WorkExperience experience)
        {
            _context.WorkExperiences.Update(experience);

            await _context.SaveChangesAsync();
        }



        public async Task DeleteWorkExperienceAsync(Guid id)
        {
            var experience = await _context.WorkExperiences.FirstOrDefaultAsync(x => x.WorkId == id);

            if (experience == null)
                throw new Exception("Work experience not found");

            _context.WorkExperiences.Remove(experience);

            await _context.SaveChangesAsync();
        }
    }
}
