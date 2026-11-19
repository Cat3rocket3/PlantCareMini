using PlantCareMini.Data.Entities;

namespace PlantCareMini.Services.Contracts
{
    public interface IPlantService
    {
        Task<List<Plant>> GetAll(string? search = null, int? growingLocationId = null);
        Task<Plant?> GetById(int id);
        Task<List<PlantType>> GetPlantTypes();
        Task<List<GrowingLocation>> GetGrowingLocations();
        Task Create(string name, int plantTypeId, int growingLocationId, int wateringIntervalDays, string description);
    }
}
