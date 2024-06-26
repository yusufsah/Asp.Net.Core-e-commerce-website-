﻿using Entites.Models;
using Entites.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contract;
using StoreApp.Models;


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


        public IActionResult Index(ProductRequestParameters p)
        {

            // var model = _Manger.ProductService.GetAllProducts(false).ToList(); // bunu unutma .ToList();  yoksa view da list değil  Ienumble kullanmak gerekir // ilk bunu kullanıyorduk 
            var model = _Manger.ProductService.GetAllProductwithDetails(p).ToList(); // bunu yeni olarak ekledik
             // return View(model);  // eski  page eklemden öncesi
            // bunu page ekledikten sonra yaptık 


            var pagination = new Pagination()
            {
                CurrenPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                Totalitems = _Manger.ProductService.GetAllProducts(false).Count()

              };
            return View(new ProductListViewModel()
            {
                products = model,
                pagination = pagination

            });
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




