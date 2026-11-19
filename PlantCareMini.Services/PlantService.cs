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

        public Task<List<Plant>> GetAll()
        {
            return _db.Plants.Include(p => p.PlantType)
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
    }
}
