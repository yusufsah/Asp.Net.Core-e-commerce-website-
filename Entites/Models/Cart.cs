using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Cart
    {


        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();

        }


        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines.Where(l => l.product.ProductId.Equals(product.ProductId)).FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CartLine()
                {

                    product = product,
                    Quantity = quantity
                });

            }
            else
            {
                line.Quantity += quantity;
            }
        }   // septe ürün ekleme


        public virtual void RemoveItem(Product product)
        {
            Lines.RemoveAll(l => l.product.ProductId.Equals(product.ProductId));

        }  // sepettekileri  kaldır



        public virtual decimal computeTotalValue() => Lines.Sum(e => e.product.Price * e.Quantity); // sepetteki  parayı hesapla  // html yampma kiçin decimal ve toplam olduğu için 




        public virtual void clear()
        {
            Lines.Clear();
        }   // sepeti temizle

    }
}
