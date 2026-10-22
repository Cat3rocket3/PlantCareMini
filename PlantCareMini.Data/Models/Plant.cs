using PlantCareMini.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantCareMini.Data.Models
{
    public class Plant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public PlantType Type { get; set; }

        [Required]
        public GrowingPlace Place { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Дните трябва да са положителни!")]
        public int WateringIntervalDays { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }   
}
