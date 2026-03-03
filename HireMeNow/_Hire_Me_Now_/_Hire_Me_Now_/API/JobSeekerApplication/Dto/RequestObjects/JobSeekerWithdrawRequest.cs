namespace _Hire_Me_Now_.API.JobSeekerApplication.Dto.RequestObjects
{
    public class JobSeekerWithdrawRequest
    {
        public Guid ApplicationId { get; set; }
        public Guid SeekerId { get; set; }
    }
}
