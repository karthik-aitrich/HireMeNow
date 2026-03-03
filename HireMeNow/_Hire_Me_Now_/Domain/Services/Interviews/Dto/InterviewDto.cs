using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interviews.Dto
{
    public class InterviewDto
    {
        public Guid InterviewId { get; set; }

        public Guid ApplicationId { get; set; }

        public DateTime? InterviewDate { get; set; }

        //enum
        public JobMode Mode { get; set; }

        public string? MeetingLink { get; set; }
        public string? Venue { get; set; }

        public string? Remark { get; set; }

        //enum
        public InterviewStatus Status { get; set; }

    }
}
