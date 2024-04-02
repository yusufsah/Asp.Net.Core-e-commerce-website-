using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class CartLine
    {


        public int CartLineId { get; set; }

        public Product product { get; set; } = new();

        public int Quantity { get; set; }
    }
}
