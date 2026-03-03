using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.WorkExperiences.Interface
{
    public interface IWorkExperienceRepository
    {
        Task <WorkExperience>AddWorkExperienceAsync(WorkExperience experience);
        Task<List<WorkExperience>> GetWorkExperienceByProfileIdAsync(Guid profileId);
        Task<WorkExperience?> GetWorkExperienceByIdAsync(Guid id);
        Task UpdateWorkExperienceAsync(WorkExperience experience);
        Task DeleteWorkExperienceAsync(Guid id);
    }
}
