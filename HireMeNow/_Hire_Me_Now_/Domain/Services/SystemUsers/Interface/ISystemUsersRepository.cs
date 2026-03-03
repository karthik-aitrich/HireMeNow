using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SystemUsers.Interface
{
    public interface ISystemUsersRepository
    {
        Task<SystemUser> GetUserByIdAsync(Guid id);
        Task<IEnumerable<SystemUser>> GetAllUsersAsync();
        Task UpdateUserAsync(SystemUser systemUser);
    }
}
