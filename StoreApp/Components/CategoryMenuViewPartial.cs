using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using Entites.Models; // Bu, Category sınıfının bulunduğu namespace olmalı. Gerekirse doğru namespace ile güncelleyin.

namespace StoreApp.Components
{
    public class CategoryMenuViewPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoryMenuViewPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _manager.CategoryService.GetAllCategories(false).ToList();
            return View(categories); // Burada IEnumerable<Category> türünde bir koleksiyon döndürüyoruz.
        }
    }
}
