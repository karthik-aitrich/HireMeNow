using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeekers.DTO
{
    public class JobSeekerJobDto
    {
        public Guid Id { get; set; }

        public Guid JobId { get; set; }
        public string JobTitle { get; set; }

        public string JobSummary { get; set; }

        public DateTime PostedDate { get; set; }

        public Guid ProviderId { get; set; }
    }
}
