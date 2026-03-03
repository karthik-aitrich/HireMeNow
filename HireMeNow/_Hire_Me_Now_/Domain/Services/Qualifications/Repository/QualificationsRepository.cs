using Domain.Models;
using Domain.Services.Qualifications.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Qualifications.Repository
{
    public class QualificationsRepository : IQualificationsRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public QualificationsRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<Qualification> AddQualificationAsync(Qualification qualification)
        {
            await _context.Qualifications.AddAsync(qualification);
            await _context.SaveChangesAsync();
            return qualification;
        }



        public async Task<List<Qualification>> GetByJobSeekerIdAsync(Guid jobSeekerId)
        {
            return await _context.Qualifications.Where(p => p.JobSeekerProfileId == jobSeekerId).ToListAsync();
        }



        public async Task<Qualification?> GetQualificationByIdAsync(Guid id)
        {
            return await _context.Qualifications.FirstOrDefaultAsync(p => p.Id == id);
        }



        public async Task UpdateQualificationAsync(Qualification qualification)
        {
             //_context.Qualifications.Update(qualification);
            await _context.SaveChangesAsync();
        }




        public async Task DeleteQualificationAsync(Qualification qualification)
        {
            _context.Qualifications.Remove(qualification);
            await _context.SaveChangesAsync();
        }




        //public async Task<bool> ExistsAsync(Guid id)
        //{
        //    return await _context.Qualifications
        //        .AnyAsync(q => q.Id == id);
        //}


    }
}
