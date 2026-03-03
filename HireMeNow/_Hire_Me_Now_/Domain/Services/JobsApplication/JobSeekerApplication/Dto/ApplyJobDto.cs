using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobsApplication.JobSeekerApplication.Dto
{
    public class ApplyJobDto
    {
        public Guid JobId { get; set; }
        public Guid SeekerId { get; set; }
        public Guid ProviderId { get; set; }

        public Guid ResumeId { get; set; }
        public string CoverLetter { get; set; }
    }
}
