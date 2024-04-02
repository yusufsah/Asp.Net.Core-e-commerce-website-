using Entites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Dtos
{
    public record ProductDtos
    {
        public int ProductId { get; init; }

        [Required(ErrorMessage = "ürün ismi girmediniz")]
        public String? ProductName { get; init; } = string.Empty;

        [Required(ErrorMessage = "ürün fiyatı girmediniz")]
        public decimal Price { get; init; }

        public String? summary { get; init; } = String.Empty; // özet

        public String? ImageUrl { get; set; }  // bu set olucak unutma çünkü resim yüklicez

        public int? categoryId { get; init; }  // Foreign key

        
    }
}
