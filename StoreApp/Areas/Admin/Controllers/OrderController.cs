using Entites.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {

        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }




        /// /////////////////////////////////////////////

        [HttpGet]
        public IActionResult Index()
        {
            var order = _manager.OrderService.Orders;

            return View(order);
        }
        [HttpPost]
        public IActionResult Complete([FromForm]int id) 
        {

            _manager.OrderService.Complete(id);
           return RedirectToAction("Index");
        }
    }
}
