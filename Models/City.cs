using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagement.Models
{
    public class City
    {
        [Key]
        public int IdCity { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę miasta!")]
        [Display(Name = "Miasto")]
        [StringLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 znaków.")]
        public string CityName { get; set; }

    }
}
