using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SavedJobs.Dto
{
    public class SavedJobDto
    {
        public Guid Id { get; set; }
        public Guid systemUserId { get; set; }
        public Guid JobPostId { get; set; }
        public bool IsSaved { get; set; } = false;
        public DateTime SavedOn { get; set; } = DateTime.UtcNow;
    }
}
