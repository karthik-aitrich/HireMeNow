using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Interview
    {
        [Key]
        public Guid InterviewId { get; set; }


        public Guid ApplicationId { get; set; }
        [ForeignKey(nameof(ApplicationId))]
        public virtual Applicationn Application { get; set; } = null!;



        public DateTime? InterviewDate { get; set; }

        public JobMode Mode { get; set; }


        public string MeetingLink { get; set; }
        public string Venue { get; set; }


        public string? Remark { get; set; }

        public InterviewStatus Status { get; set; }

     
    }
}
