using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Resumes.DTO
{
    public class ResumesDto
    {
        public Guid ResumeId { get; set; }

        public string? Title { get; set; }

        public byte[]? File { get; set; }

        public DateTime UploadedAt { get; set; }

    }
}
