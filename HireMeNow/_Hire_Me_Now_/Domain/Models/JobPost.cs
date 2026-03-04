using Domain.Enums;
using Domain.Models;

public partial class JobPost
{
    public Guid Id { get; set; }

    public Guid PostedBy { get; set; }   // FK → JobProviderCompany

    public string JobTitle { get; set; } = null!;

    public string JobSummary { get; set; } = null!;

    public int JobMode { get; set; }

    public int JobType { get; set; }

    public bool IsBlocked { get; set; } = false;

    public JobStatus Status { get; set; } = JobStatus.Pending;

    public Guid JobLocation { get; set; }

    public Guid Category { get; set; }

    public Guid Industry { get; set; }

    public DateTime PostedDate { get; set; }

    public virtual Location JobLocationNavigation { get; set; } = null!;

    // Navigation to company/provider
    public virtual JobProviderCompany PostedByNavigation { get; set; } = null!;

    public virtual ICollection<JobResponsibility> JobResponsibilities { get; set; } = new List<JobResponsibility>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();

    public virtual ICollection<Applicationn> Applications { get; set; } = new List<Applicationn>();
    public virtual ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
}