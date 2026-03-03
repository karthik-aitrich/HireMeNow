using Domain.Enums;

namespace _Hire_Me_Now_.API.Interviews.Dto.RequestObject
{
    public class InterviewRequest
    {
        //public Guid InterviewId { get; set; }

        public Guid ApplicationId { get; set; }

        public DateTime? InterviewDate { get; set; }

        public JobMode Mode { get; set; }

        public string? MeetingLink { get; set; }

        public string? Venue { get; set; }

        public string? Remark { get; set; }

        //public InterviewStatus Status { get; set; }
    }
}
