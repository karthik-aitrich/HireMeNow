using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobsApplication.JobProviderApplication.Dto
{
    public class ApplyJobDto
    {
        public Guid ApplicationId { get; set; }
        public Guid ProviderId { get; set; }
        public ApplicationStatus Status { get; set; }

    }
}
