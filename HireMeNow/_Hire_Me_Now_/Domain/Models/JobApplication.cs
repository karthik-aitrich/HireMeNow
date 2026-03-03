using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Models
{
    public class JobApplication
    {
        [Key]
        public Guid ApplicationId { get; set; }

        public Guid JobId { get; set; }

        public Guid SeekerId { get; set; }

        public Guid ProviderId { get; set; }



        public Guid ResumeId { get; set; }

        public virtual JobPost? Job { get; set; }

        public virtual Resume? Resume { get; set; }
        public string CoverLetter { get; set; }

        public DateTime AppliedDate { get; set; }

        public ApplicationStatus Status { get; set; }

    }
}
