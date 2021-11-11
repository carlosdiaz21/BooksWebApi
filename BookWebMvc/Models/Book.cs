using System;
using System.ComponentModel.DataAnnotations;

namespace BookWebMvc.Models
{
    public class Book
    {
        [Key]
        [Display(Name = "Codigo")]
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Descripcion")]
        public string? Description { get; set; }

        [Display(Name = "Paguinas")]
        public int PageCount { get; set; }

        [Display(Name = "Extracto")]
        public string Excerpt { get; set; }

        public DateTime PublishDate { get; set; }
    }
}