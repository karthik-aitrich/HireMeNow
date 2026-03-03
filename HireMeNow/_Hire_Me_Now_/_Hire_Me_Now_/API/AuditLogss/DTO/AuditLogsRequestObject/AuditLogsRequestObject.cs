namespace _Hire_Me_Now_.API.AuditLogss.DTO.AuditLogsRequestObject
{
    public class AuditLogsRequestObject
    {
        public Guid UserId { get; set; }
        public string Action { get; set; } = null!;
        public string EntityName { get; set; } = null!;
    }
}
