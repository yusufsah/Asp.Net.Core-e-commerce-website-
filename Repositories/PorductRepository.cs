using Entites.Models;
using Entites.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Repositories.Contracts;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public sealed class PorductRepository : RepositoryBase<Product>,IProductRepository
    {
        public PorductRepository(RepositoryContext context) : base(context)
        {

        }

       


        /// /////////////////////////////////////////

        public IQueryable<Product> GetAllProducts(bool trackChanges)
        {
            return FindAll(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChangrs)
        {
            return FindByCondition(p => p.ProductId.Equals(id), trackChangrs); // burası önemli 

        }
        ///////////////////////////////////////////////////
        ///
        public void createproduct(Product product)
        {
           create(product);
        }


        ////////////////////////////////////////////////////
        ///
        public void DeleteOneProduct(Product product)
        {
            Remove(product);
        }



        ///////////////////////////////

        public void UpadateOneProduct(Product product)
        {
            Update(product);
        }



        ///////////////////////////////////////////////////////
        ///

        public IQueryable<Product> GetAllshowcaseProduct(bool trackChanges)  
        {
            return FindAll(trackChanges).Where(p => p.ShowCase.Equals(true));
        }

       
        /// ////////////////////////////////////////////////////////////////////
        


        public IQueryable<Product> GetAllProductwithDetails(ProductRequestParameters p)
        {

            return _context.Products.FilterByCategoryId(p.categoryId) // NORMALDE  BURDA BİTİYORDU AMA SEARCH ELDİĞİMİZ İÇİN ARTI EKLEME YAPTIK
                                                    .FilterbySearch(p.SearchTerm)
                                                    .FilterbyPrice(p.MinPrice,p.MaxPrice,p.isValiPrice);



              // return p is null      // bu eski yol  ProductRepositoriesExtensions  yokken yaptığımız
              //    ? _context.Products.Include(pr => pr.Category)
              //   : _context.Products.Include(pr => pr.Category).Where(pr => pr.categoryId.Equals(p.categoryId));




        }



        /// ////////////////////////////////////////////////////////////////////////////



    }
}
