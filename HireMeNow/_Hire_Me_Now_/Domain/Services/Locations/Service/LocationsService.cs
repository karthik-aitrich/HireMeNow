using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Services.Locations.DTO;
using Domain.Services.Locations.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Locations.Service
{
    public class LocationsService:ILocationsService
    {
        private readonly ILocationsRepository _locationsRepository;
        private readonly IMapper _mapper;

        public LocationsService(ILocationsRepository locationsRepository, IMapper mapper)
        {
            _locationsRepository = locationsRepository;
            _mapper = mapper;
        }

        public async Task<LocationsDto> AddLocationAsync(LocationsDto locationsDto)
        {
            var location=_mapper.Map<Location>(locationsDto);

            var result=await _locationsRepository.AddLocationAsync(location);

            return _mapper.Map<LocationsDto>(result);

        }

        public async Task<IEnumerable<LocationsDto>> GetAllLocationsAsync()
        {
            var location = await _locationsRepository.GetAllLocationsAsync();
            return _mapper.Map<IEnumerable<LocationsDto>>(location);
        }

        public async Task<LocationsDto?> GetLocationByIdAsync(Guid id)
        {
            var location=await _locationsRepository.GetLocationByIdAsync(id);

            if(location==null)
            {
                throw new NotFoundException($"Location with Id {id} not found.");

            }

            return _mapper.Map<LocationsDto>(location);
        }

        public async Task<bool> UpdateLocationAsync(Guid id, LocationsDto locationsDto)
        {
            var existingLocation=await _locationsRepository.GetLocationByIdAsync(id);

            if (existingLocation == null)
            {
                throw new NotFoundException($"Location with Id {id} not found.");

            }

            _mapper.Map(locationsDto, existingLocation);

            await _locationsRepository.UpdateLocationAsync(existingLocation);
            return true;
        }

        public async Task<bool> DeleteLocationAsync(Guid id)
        {
            var existingLocation = await _locationsRepository.GetLocationByIdAsync(id);

            if (existingLocation == null)
            {
                throw new NotFoundException($"Location with Id {id} not found.");

            }

            await _locationsRepository.DeleteLocationAsync(id);
            return true;
        }
    }
}
