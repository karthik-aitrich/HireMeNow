namespace _Hire_Me_Now_.API.JobSeekerApplication.Dto.RequestObjects
{
    public class JobSeekerApplyRequest
    {
        public Guid JobId { get; set; }
        public Guid SeekerId { get; set; }

        public Guid ResumeId     { get; set; }
        public string CoverLetter { get; set; }
    }
}
