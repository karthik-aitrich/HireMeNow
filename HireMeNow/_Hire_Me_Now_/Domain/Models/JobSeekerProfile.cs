using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class JobSeekerProfile
{
    public Guid Id { get; set; }

    public string? ProfileName { get; set; }

    public string? ProfileSummary { get; set; }

    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();

    public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
    public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
}
