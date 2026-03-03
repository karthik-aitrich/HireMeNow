using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobsApplication.JobProviderApplication.Dto
{
    public class JobSeekerApplicationDto
    {
        public Guid ApplicationId { get; set; }

        public Guid JobId { get; set; }

        public string JobTitle { get; set; }

        public DateTime AppliedDate { get; set; }

        public ApplicationStatus Status { get; set; }

        public Guid ResumeId { get; set; }
        public string CoverLetter { get; set; }

        public Guid SeekerId { get; set; }

    }
}
