namespace _Hire_Me_Now_.API.AuditLogss.DTO.AuditLogsResponseObject
{
    public class AuditLogsResponseObject
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Action { get; set; } = null!;
        public string EntityName { get; set; } = null!;
        public string? Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
