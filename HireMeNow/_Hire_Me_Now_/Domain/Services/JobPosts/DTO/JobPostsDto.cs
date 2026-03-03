using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobPosts.DTO
{
    public class JobPostsDto
    {
        public Guid Id { get; set; }

        public string JobTitle { get; set; } = null!;

        public string JobSummary { get; set; } = null!;
        public JobMode JobMode { get; set; }
        public JobType JobType { get; set; }
        public bool IsBlocked { get; set; } = false;

        public JobStatus Status { get; set; } = JobStatus.Pending;
        public Guid JobLocation { get; set; }

        //public Guid Company { get; set; }
        public string CompanyName { get; set; }

        public Guid Category { get; set; }

        public Guid Industry { get; set; }

        public Guid PostedBy { get; set; }

        public DateTime PostedDate { get; set; }
        public List<JobResponsibilityDto>? Responsibilities { get; set; }
    }

    public class JobResponsibilityDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
