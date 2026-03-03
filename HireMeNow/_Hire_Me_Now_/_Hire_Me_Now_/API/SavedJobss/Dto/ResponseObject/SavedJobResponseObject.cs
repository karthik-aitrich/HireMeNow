namespace _Hire_Me_Now_.API.SavedJobss.Dto.ResponseObject
{
    public class SavedJobResponseObject
    {
        public Guid Id { get; set; }
        public Guid systemUserId { get; set; }
        public Guid JobPostId { get; set; }
        public bool IsSaved { get; set; }
        //public DateTime SavedOn { get; set; } = DateTime.UtcNow;
    }
}
