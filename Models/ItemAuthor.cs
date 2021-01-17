using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagement.Models
{
    public class ItemAuthor
    {
        [Key]
        public int IdItemAuthor { get; set; }

        [Display(Name = "ID eksponatu")]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Display(Name = "ID autora")]
        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
