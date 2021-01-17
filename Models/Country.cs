using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagement.Models
{
    public class Country
    {
        [Key]
        public int IdCountry { get; set; }

        [Required(ErrorMessage = "Prosze podac kraj!")]
        [Display(Name = "Kraj")]
        [StringLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 znaków.")]
        public string CountryName { get; set; }
    }
}
