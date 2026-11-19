using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantCareMini.Data.Entities
{
    public class Plant
    {
        public int PlantId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(PlantType))]
        public int PlantTypeId { get; set; }

        [ForeignKey(nameof(GrowingLocation))]
        public int GrowingLocationId { get; set; }

        [Required]
        public int WateringIntervalDays { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        // Navigation properties
        public PlantType PlantType { get; set; } = null!;
        public GrowingLocation GrowingLocation { get; set; } = null!;
    }
}
