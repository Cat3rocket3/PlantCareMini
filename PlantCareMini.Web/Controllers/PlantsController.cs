using Microsoft.AspNetCore.Mvc;
using PlantCareMini.Data.Entities;
using PlantCareMini.Services.Contracts;

namespace PlantCareMini.Web.Controllers
{
    public class PlantsController : Controller
    {
        private readonly IPlantService _plantService;

        public PlantsController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        public async Task<IActionResult> Index(string? search, int? growingLocationId)
        {
            var plants = await _plantService.GetAll(search, growingLocationId);
            ViewBag.Search = search;
            ViewBag.GrowingLocationId = growingLocationId;
            ViewBag.GrowingLocations = await _plantService.GetGrowingLocations();
            return View(plants);
        }

        public async Task<IActionResult> Details(int id)
        {
            var plant = await _plantService.GetById(id);
            if (plant == null)
            {
                return NotFound();
            }
            return View(plant);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.PlantTypes = await _plantService.GetPlantTypes();
            ViewBag.GrowingLocations = await _plantService.GetGrowingLocations();
            return View(new Plant { WateringIntervalDays = 1 });
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, int plantTypeId, int growingLocationId, int wateringIntervalDays, string description)
        {
            var plantTypes = await _plantService.GetPlantTypes();
            var locations = await _plantService.GetGrowingLocations();
            var plantType = plantTypes.FirstOrDefault(t => t.PlantTypeId == plantTypeId);
            var location = locations.FirstOrDefault(l => l.GrowingLocationId == growingLocationId);

            if (!string.IsNullOrWhiteSpace(name) && name.Length <= 100 &&
                !string.IsNullOrWhiteSpace(description) && description.Length <= 2000 &&
                wateringIntervalDays > 0 && plantType != null && location != null)
            {
                await _plantService.Create(name, plantTypeId, growingLocationId, wateringIntervalDays, description);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = "Enter a name (up to 100 characters), a description (up to 2000 characters), an existing type and location, and a positive watering interval.";
            ViewBag.PlantTypes = plantTypes;
            ViewBag.GrowingLocations = locations;
            return View(new Plant
            {
                Name = name,
                PlantTypeId = plantTypeId,
                GrowingLocationId = growingLocationId,
                WateringIntervalDays = wateringIntervalDays,
                Description = description
            });
        }
    }
}
