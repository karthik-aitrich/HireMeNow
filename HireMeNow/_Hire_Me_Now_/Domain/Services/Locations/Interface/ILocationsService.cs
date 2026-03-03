using Domain.Models;
using Domain.Services.Locations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Locations.Interface
{
    public interface ILocationsService
    {
        Task<LocationsDto> AddLocationAsync(LocationsDto locationsDto);
        Task<IEnumerable<LocationsDto>> GetAllLocationsAsync();
        Task<LocationsDto?> GetLocationByIdAsync(Guid id);
        Task<bool> UpdateLocationAsync(Guid id,LocationsDto locationsDto);
        Task<bool> DeleteLocationAsync(Guid id);
    }
}
