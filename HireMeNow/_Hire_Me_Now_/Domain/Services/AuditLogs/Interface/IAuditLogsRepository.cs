using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AuditLogs.Interface
{
    public interface IAuditLogsRepository
    {
        Task<IEnumerable<AuditLog>> GetAllLogsAsync();
        Task<IEnumerable<AuditLog>> GetLogsByUserIdAsync(Guid userId);
        Task AddLogAsync(AuditLog auditLog);
    }
}
