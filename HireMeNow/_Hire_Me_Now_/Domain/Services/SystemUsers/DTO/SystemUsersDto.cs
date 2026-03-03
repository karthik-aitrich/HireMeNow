using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SystemUsers.DTO
{
    public class SystemUsersDto
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Role { get; set; }
        public bool IsBlocked { get; set; } 
    }
}
