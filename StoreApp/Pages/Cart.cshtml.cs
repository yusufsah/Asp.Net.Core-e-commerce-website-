using Entites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contract;
using StoreApp.Infrastruckte.Extensions;
using StoreApp.Models;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {

        private readonly IServiceManager _manager;
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public CartModel(IServiceManager manager,Cart cartservice)
        {
            _manager = manager;
            Cart = cartservice;
               
           
        }

   
        /// <summary>
        /// /////////////////////////////////////////////////



        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

        }

        public IActionResult OnPost(int ProductId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetOneProduct(ProductId, false);

            if (product is not null) 
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product,1);
               // HttpContext.Session.SetJson<Cart>("cart", Cart);

            }
            return RedirectToPage(new {returnUrl = returnUrl});
        }


        //////////////////////////
        ///
        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveItem(Cart.Lines.First(cl => cl.product.ProductId.Equals(id)).product);
            //HttpContext.Session.SetJson<Cart>("cart", Cart);

            return Page();

        }
    }
}
