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

        public async Task<IActionResult> Index()
        {
            var plants = await _plantService.GetAll();
            return View(plants);
        }
    }
}
