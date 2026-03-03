using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobsApplication.JobSeekerApplication.Dto
{
    public class JobSeekerWithdrawApplicationDto
    {
        public Guid ApplicationId { get; set; }
        public Guid SeekerId { get; set; }
    }
}
