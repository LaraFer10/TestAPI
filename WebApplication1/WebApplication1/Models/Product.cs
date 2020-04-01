using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60, ErrorMessage = "Campo aceita de 3 a 60 caracteres.")]
        [MinLength(3, ErrorMessage = "Campo aceita de 3 a 60 caracteres.")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "Campo aceita ate 1024 caracteres.")]
        public string Description { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
