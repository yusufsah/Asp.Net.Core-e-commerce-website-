using Entites.Models;

namespace StoreApp.Models
{
    public class ProductListViewModel
    {

        public IEnumerable<Product> products { get; set; } = Enumerable.Empty<Product>();

        public Pagination pagination { get; set; } = new();


        public int TotalCount => products.Count();
    }
}
