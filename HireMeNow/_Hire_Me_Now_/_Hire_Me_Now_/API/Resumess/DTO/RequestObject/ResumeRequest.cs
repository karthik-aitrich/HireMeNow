namespace _Hire_Me_Now_.API.Resumess.DTO.RequestObject
{
    public class ResumeRequest
    {
        //public Guid ResumeId { get; set; }

        public string? Title { get; set; }

        public IFormFile? File { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
