using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManger
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly RepositoryContext _context;

        public RepositoryManager(IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, RepositoryContext context)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _context = context;
        }





        /// //////////////////////////////////////////////////////////////

        public IProductRepository Product => _productRepository;   // biz yazdık  = _productRepository; 

        public ICategoryRepository Category => _categoryRepository; //  ""   ""    ""     "" 

        public IOrderRepository Order => _orderRepository;

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
