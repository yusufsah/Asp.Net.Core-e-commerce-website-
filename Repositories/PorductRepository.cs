using Entites.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PorductRepository : RepositoryBase<Product>,IProductRepository
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
    }
}
