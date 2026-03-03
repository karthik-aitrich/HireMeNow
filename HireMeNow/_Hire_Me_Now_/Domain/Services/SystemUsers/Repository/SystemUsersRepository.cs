using Domain.Models;
using Domain.Services.SystemUsers.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SystemUsers.Repository
{
    public class SystemUsersRepository:ISystemUsersRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public SystemUsersRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<SystemUser> GetUserByIdAsync(Guid id)
        {
            var user=await _context.SystemUsers.FirstOrDefaultAsync(i=>i.Id==id);
            return user;
        }

        public async Task<IEnumerable<SystemUser>> GetAllUsersAsync()
        {
            var user =await  _context.SystemUsers.ToListAsync();
            return user;
        }

        public async Task UpdateUserAsync(SystemUser systemUser)
        {
            _context.SystemUsers.Update(systemUser);
            await _context.SaveChangesAsync();
        }
    }
}
