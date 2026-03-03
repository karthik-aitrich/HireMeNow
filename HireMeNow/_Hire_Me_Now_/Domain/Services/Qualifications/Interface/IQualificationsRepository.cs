using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Qualifications.Interface
{
    public interface IQualificationsRepository
    {
        Task <Qualification>AddQualificationAsync(Qualification qualification);

        Task<List<Qualification>> GetByJobSeekerIdAsync(Guid jobSeekerId);

        Task<Qualification?> GetQualificationByIdAsync(Guid id);

        Task UpdateQualificationAsync(Qualification qualification);

        Task DeleteQualificationAsync(Qualification qualification);

        //Task<bool> ExistsAsync(Guid id);
    }
}
