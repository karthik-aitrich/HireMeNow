using Domain.Models;
using Domain.Services.Qualifications.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Qualifications.Interface
{
    public interface IQualificationsService
    {
        Task <QualificationsDto>AddQualificationAsync(Guid jobSeekerId, QualificationsDto dto);

        Task<List<QualificationsDto>> GetQualificationsAsync(Guid jobSeekerId);

        Task<QualificationsDto?> GetQualificationByIdAsync(Guid qualificationId, Guid jobSeekerId);

        Task UpdateQualificationAsync(Guid qualificationId, Guid jobSeekerId, QualificationsDto dto);

        Task DeleteQualificationAsync(Guid qualificationId, Guid jobSeekerId);
    }
}
