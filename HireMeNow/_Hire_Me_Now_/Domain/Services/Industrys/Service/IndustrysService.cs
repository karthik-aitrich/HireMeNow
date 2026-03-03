using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Services.Industrys.DTO;
using Domain.Services.Industrys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Industrys.Service
{
    public class IndustrysService:IIndustrysService
    {
        private readonly IIndustrysRepository _industrysRepository;
        private readonly IMapper _mapper;

        public IndustrysService(IIndustrysRepository industrysRepository, IMapper mapper)
        {
            _industrysRepository = industrysRepository;
            _mapper = mapper;
        }

        public async Task<IndustrysDto> AddIndustryAsync(IndustrysDto industrysDto)
        {
            var industry=_mapper.Map<Industry>(industrysDto);

            var result = await _industrysRepository.AddIndustryAsync(industry);

            return _mapper.Map<IndustrysDto>(result);

        }
        public async Task<IEnumerable<IndustrysDto>> GetAllIndustrysAsync()
        {
            var industry=await _industrysRepository.GetAllIndustrysAsync();
            return _mapper.Map<IEnumerable<IndustrysDto>>(industry);
        }
        
        public async Task<IndustrysDto?> GetIndustryByIdAsync(Guid id)
        {
            var industry=await _industrysRepository.GetIndustryByIdAsync(id);

            if(industry==null)
            {
                throw new NotFoundException($"Industry with {id} not found.");
            }

            return _mapper.Map<IndustrysDto>(industry);
        }

        public async  Task<bool> UpdateIndustryAsync(Guid id, IndustrysDto industrysDto)
        {
            var existingIndustry = await _industrysRepository.GetIndustryByIdAsync(id);

            if (existingIndustry==null)
            {
                throw new NotFoundException($"Industry with {id} not found.");
            }

            _mapper.Map(industrysDto, existingIndustry);
            await _industrysRepository.UpdateIndustryAsync(existingIndustry);
            return true;
        }

        public async Task<bool> DeleteIndustryAsync(Guid id)
        {
            var existingIndustry = await _industrysRepository.GetIndustryByIdAsync(id);

            if (existingIndustry == null)
            {
                throw new NotFoundException($"Industry with {id} not found.");
            }

            await _industrysRepository.DeleteIndustryAsync(id);
            return true;
        }
    }
}
