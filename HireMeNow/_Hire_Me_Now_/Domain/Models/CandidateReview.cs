using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CandidateReview
    {
        [Key]
        public Guid ReviewId { get; set; }

        public Guid ApplicationId { get; set; }

        public Guid ProviderId { get; set; }

        public string? Comments { get; set; }

        public DateTime CreatedAt { get; set; }

        //public virtual JobApplication JobApplication { get; set; } = null!;

        //public virtual JobProvider JobProvider { get; set; } = null!;

    }
}
