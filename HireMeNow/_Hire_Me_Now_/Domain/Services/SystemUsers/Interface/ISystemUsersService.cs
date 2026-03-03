using Domain.Services.SystemUsers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SystemUsers.Interface
{
    public interface ISystemUsersService
    {
        Task<IEnumerable<SystemUsersDto>> GetAllUsersAsync();
        Task<SystemUsersDto> GetUserByIdAsync(Guid id);
        Task<bool> BlockUserAsync(Guid id);
        Task<bool> UnblockUserAsync(Guid id);
    }
}
