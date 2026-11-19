using System.ComponentModel.DataAnnotations;

namespace PlantCareMini.Data.Entities
{
    public class Plant
    {
        public int PlantId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int WateringIntervalDays { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;
    }
}
