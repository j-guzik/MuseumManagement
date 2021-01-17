using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagement.Models
{
    public class Author
    {
        [Key]
        public int IdAuthor { get; set; }

        [Required(ErrorMessage = "Prosze podac imię autora!")]
        [Display(Name = "Imię autora")]
        [StringLength(30, ErrorMessage = "Imię nie może być dłuższe niż 30 znaków.")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Prosze podac nazwisko autora!")]
        [Display(Name = "Nazwisko autora")]
        [StringLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków.")]
        public string AuthorSurname { get; set; }

        [DataType(DataType.Date)]
        public DateTime BornDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DeathDate { get; set; }

    }
}
