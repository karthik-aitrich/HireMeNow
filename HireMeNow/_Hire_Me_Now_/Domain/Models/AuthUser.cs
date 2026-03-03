using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class AuthUser
{
    public Guid Id { get; set; }

    public Guid SystemUserId { get; set; }   // ✅ FK

    public string Password { get; set; } = null!;

    public virtual SystemUser SystemUser { get; set; } = null!;
}
