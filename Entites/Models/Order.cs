using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

        [Required(ErrorMessage ="adresi girmediniz")]
        public String? Name { get; set; }


        [Required(ErrorMessage = "adres girmediniz")]
        public String? Line1 { get; set; }   // adres için

        public String? Line2 { get; set; }

        public String? Line3 { get; set; }

        public String? City { get; set; }

        public bool   GiftWrap { get; set; }  // hediye paketi istermi

        public bool   shipped { get; set; }   // kargoya verildimi 

        public DateTime OrderTime { get; set; }= DateTime.Now;








    }
}
