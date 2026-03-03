using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SavedJob
    {
        public Guid Id { get; set; }
        public Guid systemUserId{  get; set; }
        public Guid JobPostId { get; set; }
        public bool IsSaved {  get; set; }=false;
        public DateTime SavedOn { get; set; } = DateTime.UtcNow;

        public virtual SystemUser systemUser { get; set; } = null;
        public virtual JobPost JobPost { get; set; } = null;

    }
}
