using Domain.Services.Resumes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Resumes.Interface
{
    public interface IResumesService
    {
        Task<ResumesDto> CreateResumeAsync(Guid userId, ResumesDto dto);

        Task<List<ResumesDto>> GetMyResumeAsync(Guid userId);

        Task <ResumesDto>UpdateResumeAsync(Guid resumeId, Guid userId, ResumesDto dto);

        Task DeleteResumeAsync(Guid resumeId, Guid userId);


        Task<IEnumerable<ResumesDto>> GetAllResumeAsync();
    }
}
