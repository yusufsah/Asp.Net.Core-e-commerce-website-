using Entites.Models;
using Entites.RequestParameters;
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

        IQueryable<Product> GetAllshowcaseProduct(bool trackChanges);  //bunu sorandan yazdık showcase ekledikten sonra // vitrine cıkıcak ürünlerin listesi  


        IQueryable<Product> GetAllProductwithDetails(ProductRequestParameters p);  // ürünleri categrotrilerine göre veya getirmek için
        public Product? GetOneProduct(int id, bool trackChangrs);  // 1 tane getir


        void  createproduct(Product product);  // oluştur



        void DeleteOneProduct(Product product);  // 1 tane sil


        // update burda oluşturmadık service yazdım unutma 

        void UpadateOneProduct(Product product);  // normalde apdate burda oluşturmadık ama dto ekliyince  dekrar ekledik 



         
    }
}
