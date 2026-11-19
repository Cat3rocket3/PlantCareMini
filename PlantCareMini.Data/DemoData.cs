using PlantCareMini.Data.Entities;
using PlantCareMini.Data.Enums;

namespace PlantCareMini.Data
{
    public static class DemoData
    {
        public static void Seed(PlantCareDbContext db)
        {
            if (db.PlantTypes.Any(t => t.Name == "Rose") &&
                db.GrowingLocations.Any(l => l.Name == "Garden"))
            {
                return;
            }

            var plantType = db.PlantTypes.FirstOrDefault(t => t.Name == "Rose");
            if (plantType is null)
            {
                plantType = new PlantType
                {
                    Name = "Rose",
                    Category = PlantCategory.Flower,
                    LightRequirement = LightRequirement.Sun
                };
                db.PlantTypes.Add(plantType);
            }

            var location = db.GrowingLocations.FirstOrDefault(l => l.Name == "Garden");
            if (location is null)
            {
                location = new GrowingLocation
                {
                    Name = "Garden",
                    LocationType = LocationType.Garden
                };
                db.GrowingLocations.Add(location);
            }

            var plant = new Plant
            {
                Name = "Demo rose",
                PlantType = plantType,
                GrowingLocation = location,
                WateringIntervalDays = 3,
                Description = "A rose growing in the garden."
            };

            db.Plants.Add(plant);
            db.SaveChanges();
        }
    }
}
