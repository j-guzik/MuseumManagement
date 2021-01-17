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

        [Display(Name = "ID eksponatu")]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Display(Name = "ID wystawy")]
        public int ExhibitionId { get; set; }

        public Exhibition Exhibition { get; set; }

        [Display(Name = "Od")]
        [DataType(DataType.Date)]
        public DateTime TimeFrom { get; set; }

        [Display(Name = "Do")]
        [DataType(DataType.Date)]
        public DateTime TimeTo { get; set; }

    }
}
