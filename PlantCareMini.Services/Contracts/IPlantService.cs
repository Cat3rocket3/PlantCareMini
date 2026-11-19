using PlantCareMini.Data.Entities;

namespace PlantCareMini.Services.Contracts
{
    public interface IPlantService
    {
        Task<List<Plant>> GetAll();
    }
}
