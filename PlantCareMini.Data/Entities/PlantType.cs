using System.ComponentModel.DataAnnotations;
using PlantCareMini.Data.Enums;

namespace PlantCareMini.Data.Entities
{
    public class PlantType
    {
        public int PlantTypeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public PlantCategory Category { get; set; }
        public LightRequirement LightRequirement { get; set; }
        public ICollection<Plant> Plants { get; set; } = new List<Plant>();
    }
}
