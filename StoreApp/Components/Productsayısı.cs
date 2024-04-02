using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contract;

namespace StoreApp.Components
{
    public class Productsayısı : ViewComponent
    {
        private readonly IServiceManager _manager; //

        public Productsayısı(IServiceManager manager)
        {
            _manager = manager;
        }




        ////////////////////////////////////////////////////////////
        ///

        public string Invoke()
        {
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
        }


    }
}
