using Microsoft.EntityFrameworkCore;
using PlantCareMini.Data;
using PlantCareMini.Data.Entities;
using PlantCareMini.Services.Contracts;

namespace PlantCareMini.Services
{
    public class PlantService : IPlantService
    {
        private readonly PlantCareDbContext _db;

        public PlantService(PlantCareDbContext context)
        {
            _db = context;
        }

        public async Task<List<Plant>> GetAll(string? search = null, int? growingLocationId = null)
        {
            var plants = _db.Plants.Where(p => !growingLocationId.HasValue || p.GrowingLocationId == growingLocationId);

            if (!string.IsNullOrWhiteSpace(search))
            {
                plants = plants.Where(p => p.Name.Contains(search.Trim()));
            }

            return await plants.Include(p => p.PlantType)
                .Include(p => p.GrowingLocation).OrderBy(p => p.Name).ToListAsync();
        }

        public Task<List<PlantType>> GetPlantTypes()
        {
            return _db.PlantTypes.ToListAsync();
        }

        public Task<List<GrowingLocation>> GetGrowingLocations()
        {
            return _db.GrowingLocations.ToListAsync();
        }

        public async Task Create(string name, int plantTypeId, int growingLocationId, int wateringIntervalDays, string description)
        {
            var plant = new Plant
            {
                Name = name,
                PlantTypeId = plantTypeId,
                GrowingLocationId = growingLocationId,
                WateringIntervalDays = wateringIntervalDays,
                Description = description
            };

            _db.Plants.Add(plant);
            await _db.SaveChangesAsync();
        }
    }
}
