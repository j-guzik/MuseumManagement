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

        [Required(ErrorMessage = "Prosze podac nazwę!")]
        [Display(Name = "Wystawa")]
        [StringLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 znaków.")]
        public string ExhibitionName { get; set; }

        [Display(Name = "ID muzeum")]
        public int MuseumId { get; set; }

        public Museum Museum { get; set; }
    }
}
