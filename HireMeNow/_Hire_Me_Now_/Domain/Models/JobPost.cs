using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class JobPost
{
    public Guid ProviderId { get; set; }
    public Guid Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public string JobSummary { get; set; } = null!;

    public int JobMode { get; set; }

    public int JobType { get; set; }

    public bool IsBlocked { get; set; } = false;

    public JobStatus Status { get; set; } = JobStatus.Pending;
 

    public Guid JobLocation { get; set; }

    //public Guid Company { get; set; }  
    public string CompanyName { get; set; }

    public Guid Category { get; set; }

    public Guid Industry { get; set; }

    public Guid PostedBy { get; set; }     

    public DateTime PostedDate { get; set; }

    public virtual Location JobLocationNavigation { get; set; } = null!;

    public virtual ICollection<JobResponsibility> JobResponsibilities { get; set; } = new List<JobResponsibility>();


    //public virtual CompanyUser PostedByNavigation { get; set; } = null!; //need to change to provider company class
    public virtual SystemUser PostedByNavigation { get; set; }=null!;

    //public virtual SystemUser PostedByNavigation { get; set; }


    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
    public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
    public virtual ICollection<Applicationn> Applications { get; set; } = new List<Applicationn>();

}
