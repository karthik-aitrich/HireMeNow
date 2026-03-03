using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Locations.Interface
{
    public interface ILocationsRepository
    {
        Task<Location> AddLocationAsync(Location location);
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task<Location?> GetLocationByIdAsync(Guid id);
        Task UpdateLocationAsync(Location location);
        Task DeleteLocationAsync(Guid id);
    }
}
