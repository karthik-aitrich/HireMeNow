using Domain.Enums;

namespace _Hire_Me_Now_.API.JobPostss.DTO.ResponseObject
{
    public class JobPostResponseObject
    {
        public Guid Id { get; set; }

        public string JobTitle { get; set; } = null!;

        public string JobSummary { get; set; } = null!;
        public JobMode JobMode { get; set; }
        public JobType JobType { get; set; }
        public bool IsBlocked { get; set; } = false;

        public JobStatus Status { get; set; }
        public Guid JobLocation { get; set; }

        //public Guid Company { get; set; }
        public string CompanyName { get; set; }

        public Guid Category { get; set; }

        public Guid Industry { get; set; }

        public Guid PostedBy { get; set; }

        public DateTime PostedDate { get; set; }
        public List<JobResponsibilityResponse>? Responsibilities { get; set; }
    

    public class JobResponsibilityResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
}
