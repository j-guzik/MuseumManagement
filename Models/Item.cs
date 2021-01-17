using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagement.Models
{
    public class Item
    {
        [Key]
        public int IdItem { get; set; }

        [Required(ErrorMessage = "Proszę podac nazwę eksponatu!")]
        [Display(Name = "Nazwa eksponatu")]
        [StringLength(100, ErrorMessage = "Nazwa nie może być dłuższa niż 100 znaków.")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Proszę podać rok powstania eksponatu!")]
        [Display(Name = "Rok powstania")]
        public int ItemYear { get; set; }
    }
}
