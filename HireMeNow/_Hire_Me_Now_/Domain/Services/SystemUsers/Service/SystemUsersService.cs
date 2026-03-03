using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Services.SystemUsers.DTO;
using Domain.Services.SystemUsers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SystemUsers.Service
{
    public class SystemUsersService:ISystemUsersService
    {
        private readonly ISystemUsersRepository _systemUsersRepository;
        private readonly IMapper _mapper;

        public SystemUsersService(ISystemUsersRepository systemUsersRepository, IMapper mapper)
        {
            _systemUsersRepository = systemUsersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SystemUsersDto>> GetAllUsersAsync()
        {
            var user= await _systemUsersRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<SystemUsersDto>>(user);
        }

        public async Task<SystemUsersDto> GetUserByIdAsync(Guid id)
        {
            var user=await _systemUsersRepository.GetUserByIdAsync(id);

            if(user==null)
            {
                throw new NotFoundException($"{id}User with this {id} not found");
            }
            return _mapper.Map<SystemUsersDto>(user);
        }

        public async Task<bool> BlockUserAsync(Guid id)
        {
            var user = await _systemUsersRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException($"{id}User with this {id} not found");
            }

            user.IsBlocked = true;
            await _systemUsersRepository.UpdateUserAsync(user);
            return true;
        }

        public async Task<bool> UnblockUserAsync(Guid id)
        {
            var user = await _systemUsersRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException($"{id}User with this {id} not found");
            }

            user.IsBlocked= false;
            await _systemUsersRepository.UpdateUserAsync(user);
            return true;
        }
    }
}
