using Domain.Enums;

namespace _Hire_Me_Now_.API.JobSeekerApplication.Dto.ResponseObjetcs
{
    public class JobSeekerApplicationResponse
    {
        public Guid ApplicationId { get; set; }
        public Guid JobId { get; set; }
        public string Status { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}
