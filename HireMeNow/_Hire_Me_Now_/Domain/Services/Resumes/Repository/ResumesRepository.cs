using Domain.Models;
using Domain.Services.Resumes.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Resumes.Repository
{
    public class ResumesRepository : IResumeRepository
    {

        private readonly DbHireMeNowWebApiContext _context;


        public ResumesRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }


        public async Task AddResumeAsync(Resume resume)
        {
            await _context.Resumes.AddAsync(resume);
            await _context.SaveChangesAsync();
        }



        public async Task<List<Resume>> GetMyResumeAsync(Guid id )
        {
            var resume =  await _context.Resumes.Where(r => r.SeekerProfileId == id).ToListAsync();
            return resume;
        }



        public async Task UpdateResumeAsync(Resume resume)
        {
             _context.Resumes.Update(resume);
            await _context.SaveChangesAsync();
        }



        public async Task DeleteResumeAsync(Resume resume)
        {


        //    var resu = await _context.Resumes
        //.Include(r => r.Applications)
        //.FirstOrDefaultAsync(r => r.Id == resumeId);

        //    if (resu == null)
        //        throw new Exception("Resume not found");

        //    _context.Applications.RemoveRange(resu.Applications);


            _context.Resumes.Remove(resume);
            await _context.SaveChangesAsync();
        }



        public async Task <IEnumerable<Resume>>GetAllResumeAsync()
        {
            return await _context.Resumes.ToListAsync(); 
        }



        public async Task<Resume?> GetResumeByIdAsync(Guid resumeId)
        {
            return await _context.Resumes.FirstOrDefaultAsync(r => r.ResumeId == resumeId);



        }



    }
}
