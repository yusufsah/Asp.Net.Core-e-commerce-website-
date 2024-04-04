using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Components
{
    public class ShowCaseViewComponents: ViewComponent
    {
        private readonly IServiceManager _manager;

        public ShowCaseViewComponents(IServiceManager manager)
        {
            _manager = manager;
        }

        //////////////////////////////////////////////
        ///

        public IViewComponentResult Invoke()
        {
            var product = _manager.ProductService.GetAllshowcaseProduct(false);

            return View(product);
        }
    }
}
