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

        [Required(ErrorMessage = "Proszę podać nazwisko twórcy!")]
        [Display(Name = "Nazwisko")]
        [StringLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków.")]
        public string AuthorSurname { get; set; }

        [Required(ErrorMessage = "Proszę podać imię twórcy!")]
        [Display(Name = "Imię")]
        [StringLength(30, ErrorMessage = "Imię nie może być dłuższe niż 30 znaków.")]
        public string AuthorName { get; set; }


    }
}
