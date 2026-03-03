using Domain.Services.WorkExperiences.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.WorkExperiences.Interface
{
    public interface IWorkExperiencesService
    {
        Task<WorkExperienceDto> AddWorkExperienceAsync(Guid ProfileId ,WorkExperienceDto dto);
        Task<List<WorkExperienceDto>> GetWorkExperienceByProfileIdAsync(Guid id , Guid profileId);
        Task<WorkExperienceDto?> GetWorkExperienceByIdAsync(Guid id , Guid profileId);
        Task UpdateWorkExperienceAsync(Guid id, Guid profileId, WorkExperienceDto dto);
        Task DeleteWorkExperienceAsync(Guid id, Guid profileId);
    }
}
