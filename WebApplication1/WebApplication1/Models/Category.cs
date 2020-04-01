using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório.")]
        [MaxLength(60, ErrorMessage ="Campo aceita de 3 a 60 caracteres.")]
        [MinLength(3, ErrorMessage = "Campo aceita de 3 a 60 caracteres.")]
        public string Title { get; set; }

    }
}
