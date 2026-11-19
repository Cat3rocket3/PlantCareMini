using System.ComponentModel.DataAnnotations;

namespace PlantCareMini.Data.Entities
{
    public class PlantType
    {
        public int PlantTypeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
