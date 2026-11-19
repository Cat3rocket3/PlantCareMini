using System.ComponentModel.DataAnnotations;
using PlantCareMini.Data.Enums;

namespace PlantCareMini.Data.Entities
{
    public class GrowingLocation
    {
        public int GrowingLocationId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public LocationType LocationType { get; set; }
        public ICollection<Plant> Plants { get; set; } = new List<Plant>();
    }
}
