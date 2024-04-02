using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts; // IRepositoryManager'ın tanımlandığı namespace'i ekledim.

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepositoryManger _manager;

        public CategoryController(IRepositoryManger manager)
        {
            _manager = manager;
        }

        
        /// ////////////////////////////////////////////////
        
        public IActionResult Index()
        {
            var model = _manager.Category.FindAll(false);
            return View(model);
        }
    }
}
