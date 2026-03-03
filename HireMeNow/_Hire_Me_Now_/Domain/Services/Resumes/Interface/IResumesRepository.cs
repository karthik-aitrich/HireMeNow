using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Resumes.Interface
{
        public interface IResumeRepository
        {
            Task AddResumeAsync(Resume resume);

            Task<List<Resume?>> GetMyResumeAsync(Guid id);
        
            Task UpdateResumeAsync(Resume resume);
        
            Task DeleteResumeAsync(Resume resume);

            Task<Resume?> GetResumeByIdAsync(Guid resumeId);

            Task<IEnumerable<Resume>> GetAllResumeAsync();

    }
    
}
