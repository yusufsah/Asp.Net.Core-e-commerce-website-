using Entites.Dtos;
using Entites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contract;
using System.Security.Cryptography.X509Certificates;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }


        /// /////////////////////////////////////////////////////

        public IActionResult Index()  // ürünleri listeleme admin kısmı 
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }


        /// ///////////////////////////////////////////////////
        [HttpGet]
        public IActionResult Creat() {   // ismi yanlışlıkla creat yazdım   burası ürün ekleme kısmı

            ViewBag.categores = new SelectList(_manager.CategoryService.GetAllCategories(false), "categoryId", "categoryName", "1");


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creat([FromForm] ProductDtosForinsertion productDto,IFormFile file)  // burası Product yapmıştık sonra  dto ekleyince değiştirdim //,IFormFile file bu kısım resim seçmek için sonradan eklendi asyc o yüzden yaptık
        {

            if (ModelState.IsValid) {
                // burası resim yükleme için seçme ve yüklemek için sadede resim unutma  sonrada ekledik
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);
                using (var stream  = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/", file.FileName);  // burayı sadece resim eklemek iç yaptık 
                // file  işlemleri için yaptık  yoksa gerek yok veri eklemek içim bunlara burası sonradan eklendi

                _manager.ProductService.createproduct(productDto);

                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }

        }
        /////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 


        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.categores = new SelectList(_manager.CategoryService.GetAllCategories(false), "categoryId", "categoryName", "1");   // categriy sayfasıbdaki listeyi alamak için



            var model = _manager.ProductService.GetOneProductForUpdate(id, false);

            //var model = _manager.ProductService.GetOneProduct(id, false); // dto kullanmadan önce böyle yaptık 
            return View(model);      // bunu yaptık çünkü isimli kendiliğinden getiriyor ana ekrana  dto ve eskiside aynı işe yarıyor
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtosForUpdate product, IFormFile file)  // burası Product yapmıştık sonra  dto ekleyince değiştirdim // ve resim güncellemek için file ve asyn yaptık 
        {
            if (ModelState.IsValid) {

                // burası resim yükleme için seçme ve yüklemek için sadede resim unutma  sonrada ekledik
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                product.ImageUrl = String.Concat("/images/", file.FileName);  // burayı sadece resim eklemek iç yaptık 
                // file  işlemleri için yaptık  yoksa gerek yok veri eklemek içim bunlara burası sonradan eklendi



                // resim güncelleme olmasa yukarıya gerek yoktu
                _manager.ProductService.UpdateOneProduct(product);

                return RedirectToAction("Index");
            }
            else 
            {
                return View(); 
            
            }
            
        }
        ////////////////////////////////////////////////////////////////////////
        ///
        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);

            return RedirectToAction("Index");
            // delete işle Product index de delete buntonun içindeki asp-action="Delete"  sayesinde  çalışıyor
        }


    }
}
