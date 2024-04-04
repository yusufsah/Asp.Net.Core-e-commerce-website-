using Entites.Dtos;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IProductService
    {

        IEnumerable<Product> GetAllProducts(bool trackChanges);

        IQueryable<Product> GetAllshowcaseProduct(bool trackChanges);

        public Product? GetOneProduct(int id, bool trackChangrs);

        void createproduct(ProductDtosForinsertion productDto);  // burası Product yapmıştık sonra  dto ekleyince değiştirdim 

        void UpdateOneProduct(ProductDtosForUpdate productDto);  // burası Product yapmıştık sonra  dto ekleyince değiştirdim 

        void DeleteOneProduct(int id);

        ProductDtosForUpdate GetOneProductForUpdate(int id, bool truckChanges);  // bunu biz update için sonradan dto ekleyince oluşturduk
    }
}
