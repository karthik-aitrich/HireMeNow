using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AuditLogs.DTO
{
    public class AuditLogsDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Action { get; set; } = null!;
        public string EntityName { get; set; } = null!;
        public string? Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
