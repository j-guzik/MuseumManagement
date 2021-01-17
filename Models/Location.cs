using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagement.Models
{
    public class Location
    {
        [Key]
        public int IdLocation { get; set; }

        [Display(Name = "Eksponat")]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Display(Name = "Wystawa")]
        public int ExhibitionId { get; set; }

        public Exhibition Exhibition { get; set; }


        [Required(ErrorMessage = "Proszę podać datę!")]
        [Display(Name = "Od")]
        [DataType(DataType.Date)]
        public DateTime TimeFrom { get; set; }

        [Required(ErrorMessage = "Proszę podać datę!")]
        [Display(Name = "Do")]
        [DataType(DataType.Date)]
        public DateTime TimeTo { get; set; }

    }
}
