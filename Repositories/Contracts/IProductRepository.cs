using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);  //hepsini getir

        public Product? GetOneProduct(int id, bool trackChangrs);  // 1 tane getir


        void  createproduct(Product product);



        void DeleteOneProduct(Product product);


        // update burda oluşturmadık service yazdım unutma 

        void UpadateOneProduct(Product product);  // normalde apdate burda oluşturmadık ama dto ekliyince  dekrar ekledik 



         
    }
}
