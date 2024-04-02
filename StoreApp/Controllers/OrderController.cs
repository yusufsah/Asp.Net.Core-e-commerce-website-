using Entites.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {


        private readonly IServiceManager _manager;
        private readonly Cart _cart;

        public OrderController(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            _cart = cart;
        }


        /// //////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order()); //order getiriyor  veri tamanından get
        }
        //
        [HttpPost]
        
        public IActionResult Checkout([FromForm] Order order)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("","sepetiniz boş ödeme yapamazsınız");
            }

            if(ModelState.IsValid) 
            {
                order.Lines = _cart.Lines.ToArray();
                _manager.OrderService.SaveOrder(order);
                _cart.clear();
                return RedirectToPage("/Complete", new { OrderId = order.OrderId });



            }
            else
            {
                return View();
            }


        }


        
    }
}
