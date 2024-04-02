using Entites.Models;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;


namespace StoreApp.Components
{
    public class CartsummaryViewComponentsPartial:ViewComponent
    {

        private readonly Cart _cart;

        public CartsummaryViewComponentsPartial(Cart cart)
        {
            _cart = cart;
        }
        //////////////////////////////////////////////////////
        ///
        
        public string Invoke()  // bu cartı işinde kaç ürün var onu sayısı alma için sayfa değil
        {

            return _cart.Lines.Count().ToString();
        }
    }
}
