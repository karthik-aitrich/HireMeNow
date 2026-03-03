using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class Qualification
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;


    public Guid? JobSeekerProfileId { get; set; }

    //[ForeignKey(nameof(JobSeekerProfileId))]
    public virtual JobSeekerProfile? JobSeekerProfile { get; set; }




    public Guid? JobPostId { get; set; }

    //[ForeignKey(nameof(JobPostId))]
    public virtual JobPost? JobPost { get; set; }
}
