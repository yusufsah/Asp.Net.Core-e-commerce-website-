using Entites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contract;


namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _Manger;

        public ProductController(IServiceManager manger)
        {
            _Manger = manger;
        }



        /// ///// // // /// // //    /// ///////////////////////////


        public IActionResult Index()
        {
            var model = _Manger.ProductService.GetAllProducts(false).ToList(); // bunu unutma .ToList();  yoksa view da list değil  Ienumble kullanmak gerekir

            return View(model);
        }
        //
        public IActionResult get([FromRoute(Name ="id")]int id)  // te bir ürün almak istiyorum
        {
              var model = _Manger.ProductService.GetOneProduct(id, false);
              
            return View(model);
        }


    }
}


























//public class ProductController : Controller           // BU ESKİ HALİ BU ŞEKİDEDE ÇALIŞYOR   REPOSİTORY KATMANI OLMADAN  SADECE DBCONTEX İLE    
//{
//    private readonly RepositoryContext _repositoryContext;

//    public ProductController(RepositoryContext repositoryContext)
//    {
//        _repositoryContext = repositoryContext;
//    }



//    /// /////////////////////////

//    public IActionResult Index()
//    {
//        var model = _repositoryContext.Products.ToList();

//        return View(model);
//    }
//    //
//    public IActionResult get(int id)  // te bir ürün almak istiyorum
//    {
//        Product product = _repositoryContext.Products.First(p => p.ProductId.Equals(id));



//        return View(product);
//    }




