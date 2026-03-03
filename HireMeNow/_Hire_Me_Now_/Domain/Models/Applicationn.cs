using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Applicationn
    {
        public Guid ApplicationId { get; set; }

        public Guid? JobId { get; set; }
        [ForeignKey(nameof(JobId))]
        public virtual JobPost JobPost { get; set; } = null!;




        public Guid? SeekerId { get; set; }
        [ForeignKey(nameof(SeekerId))]
        public virtual JobSeeker JobSeeker { get; set; } = null!;



        public Guid? ResumeId { get; set; }
        [ForeignKey(nameof(ResumeId))]
        public virtual Resume Resume { get; set; } = null!;



        public string? Status { get; set; }

        public DateTime? AppliedDate { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();


      


    }
}
