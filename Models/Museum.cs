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

        [Required(ErrorMessage = "Prosze podac kraj!")]
        [Display(Name = "Kraj")]
        [StringLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 znaków.")]
        public string MuseumName { get; set; }

        [Display(Name = "ID miasta")]
        public int CityId { get; set; }

        public City City { get; set; }
    }
}
