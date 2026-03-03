using Domain.Models;
using Domain.Services.AuditLogs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AuditLogs.Interface
{
    public interface IAuditLogsService
    {
        Task<IEnumerable<AuditLogsDto>> GetAllLogsAsync();
        Task<IEnumerable<AuditLogsDto>> GetLogsByUserIdAsync(Guid userId);
        Task AddLogAsync(AuditLogsDto auditLogDto);
    }
}
