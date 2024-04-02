using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Product
    {

        public int ProductId { get; set; }

       
        public String? ProductName { get; set; } = string.Empty;

        
        public decimal Price { get; set; }

        public String? summary {  get; set; } = String.Empty; // özet

        public String? ImageUrl { get; set; }

        public int? categoryId { get; set; }  // Foreign key

        public Category? Category { get; set; } // navigation property


    }
}
