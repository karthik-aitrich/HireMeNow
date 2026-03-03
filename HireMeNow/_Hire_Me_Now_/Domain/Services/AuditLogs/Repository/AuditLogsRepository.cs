using Domain.Models;
using Domain.Services.AuditLogs.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AuditLogs.Repository
{
    public class AuditLogsRepository:IAuditLogsRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public AuditLogsRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuditLog>> GetAllLogsAsync()
        {
            var logs=await _context.AuditLogs.OrderByDescending(x=>x.CreatedAt).ToListAsync();
            return logs;
        }

        public async Task<IEnumerable<AuditLog>> GetLogsByUserIdAsync(Guid userId)
        {
            var logs=await _context.AuditLogs.Where(i=>i.Id==userId).OrderByDescending(x=>x.CreatedAt).ToListAsync();
            return logs;
        }

        public async Task AddLogAsync(AuditLog auditLog)
        {
            _context.AuditLogs.Add(auditLog);
            await _context.SaveChangesAsync();
        }
    }
}
