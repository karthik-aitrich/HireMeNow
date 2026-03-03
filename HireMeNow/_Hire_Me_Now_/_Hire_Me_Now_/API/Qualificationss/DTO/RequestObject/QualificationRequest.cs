namespace _Hire_Me_Now_.API.Qualificationss.DTO.RequestObject
{
    public class QualificationRequest
    {
        //public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public Guid? JobseekerProfileId { get; set; }

        //public Guid? JobPostId { get; set; }

    }
}
