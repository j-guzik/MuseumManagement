using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagement.Models
{
    public class Museum
    {
        [Key]
        public int IdMuseum { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę muzeum!")]
        [Display(Name = "Muzeum")]
        [StringLength(100, ErrorMessage = "Nazwa nie może być dłuższa niż 100 znaków.")]
        public string MuseumName { get; set; }

        [Display(Name = "Miasto")]
        public int CityId { get; set; }

        public City City { get; set; }
    }
}
