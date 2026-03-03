namespace _Hire_Me_Now_.API.JobSeekers.DTO.Response
{
    public class JobSeekerJobResponse
    {
        public Guid JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobSummary { get; set; }
        public Guid ProviderId { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
