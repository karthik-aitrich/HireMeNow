using System;

namespace Domain.Models
{
    public class SavedJob
    {
        public Guid Id { get; set; }

        public Guid JobSeekerProfileId { get; set; }   // Foreign Key

        public Guid JobPostId { get; set; }

        public bool IsSaved { get; set; } = false;

        public DateTime SavedOn { get; set; } = DateTime.UtcNow;

        public virtual JobSeekerProfile JobSeekerProfile { get; set; } = null!;

        public virtual JobPost JobPost { get; set; } = null!;
    }
}