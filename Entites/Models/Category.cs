using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Category
    {
        public int categoryId { get; set; }
        public String? categoryName { get; set; } = String.Empty;


        public ICollection<Product> products { get; set; } // collection property

    }
}
