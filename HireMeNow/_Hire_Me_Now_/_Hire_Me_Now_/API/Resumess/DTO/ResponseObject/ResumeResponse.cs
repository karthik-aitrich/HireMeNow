namespace _Hire_Me_Now_.API.Resumess.DTO.ResponseObject
{
    public class ResumeResponse
    {
        public Guid ResumeId { get; set; }

        public string? Title { get; set; }

        public byte[]? File { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
