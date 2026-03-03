using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class WorkExperience
{
    public Guid WorkId { get; set; }



    public Guid JobSeekerProfileId { get; set; }

    [ForeignKey(nameof(JobSeekerProfileId))]
    public virtual JobSeekerProfile JobSeekerProfile { get; set; } = null!;




    public string JobTitle { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public DateTime ServiceStart { get; set; }

    public DateTime ServiceEnd { get; set; }

  
}
