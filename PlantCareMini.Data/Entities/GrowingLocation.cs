using System.ComponentModel.DataAnnotations;

namespace PlantCareMini.Data.Entities
{
    public class GrowingLocation
    {
        public int GrowingLocationId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
