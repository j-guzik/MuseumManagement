using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagement.Models
{
    public class Exhibition
    {
        [Key]
        public int IdExhibition { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę!")]
        [Display(Name = "Nazwa wystawy")]
        [StringLength(100, ErrorMessage = "Nazwa nie może być dłuższa niż 100 znaków.")]
        public string ExhibitionName { get; set; }

        [Display(Name = "Muzeum")]
        public int MuseumId { get; set; }

        public Museum Museum { get; set; }
    }
}
