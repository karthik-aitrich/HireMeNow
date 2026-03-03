using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AuditLog
    {
        public Guid Id { get; set; }
        public Guid UserId {  get; set; }
        public string Action { get; set; } = null!;
        public string EntityName {  get; set; }= null!;
        public string? Details {  get; set; }
        public DateTime CreatedAt {  get; set; }=DateTime.UtcNow;

        public virtual SystemUser systemUser { get; set; }
    }
}
