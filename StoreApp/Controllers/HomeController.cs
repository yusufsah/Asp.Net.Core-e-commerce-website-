using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {

        
        
        /// //////////////////////////////////////////////////////
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
