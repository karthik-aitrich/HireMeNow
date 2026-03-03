using Domain.Enums;

namespace _Hire_Me_Now_.API.JobPostss.DTO.RequestObject
{
    public class JobPostsRequestObject
    {
        public string JobTitle { get; set; } = null!;
        public string JobSummary { get; set; } = null!;

        public JobMode JobMode { get; set; }
        public JobType JobType { get; set; }

        //public bool IsBlocked { get; set; } = false;

        //public JobStatus Status { get; set; } = JobStatus.Pending;

        public Guid JobLocation { get; set; }
        //public Guid Company { get; set; }
        public string CompanyName { get; set; }

        public Guid Category { get; set; }
        public Guid Industry { get; set; }


        public List<JobResponsibilityRequest>? Responsibilities { get; set; }
    }

    public class JobResponsibilityRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
