using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bookstore.Model
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Necessário informar um título.")]
        [StringLength(255)]
        public string Title { get; set; }

        [Display(Name = "Autor(a)")]
        [Required(ErrorMessage = "Necessário informar o autor.")]
        [StringLength(255)]
        public string Author { get; set; }

        [Display(Name = "Editora")]
        [Required(ErrorMessage = "Necessário informar a editora.")]
        [StringLength(255)]
        public string PublishingHouse { get; set; }

        [Display(Name = "Ano de Publicação")]
        [Required(ErrorMessage = "Necessário informar o ano de publicação.")]
        [StringLength(4)]
        public string YearOfPublishing { get; set; }

    }
}
