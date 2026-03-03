using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class Resume
{
    public Guid ResumeId { get; set; }



    public Guid SeekerProfileId { get; set; }

    [ForeignKey(nameof(SeekerProfileId))]
    public virtual JobSeekerProfile JobSeekerProfile { get; set; } = null!;



    public string? Title { get; set; }

    public byte[]? File { get; set; }


    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;


}
