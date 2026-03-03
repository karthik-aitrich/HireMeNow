using Domain.Models;
using Domain.Services.Locations.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Locations.Repository
{
    public class LocationsRepository:ILocationsRepository
    {
        private readonly DbHireMeNowWebApiContext _context;

        public LocationsRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task<Location> AddLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            var locations = await _context.Locations.ToListAsync();
            return locations;
        }

        public async Task<Location?> GetLocationByIdAsync(Guid id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(i=>i.Id==id);
            return location;
        }

        public async Task UpdateLocationAsync(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocationAsync(Guid id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(i => i.Id == id);

            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }
    }
}
