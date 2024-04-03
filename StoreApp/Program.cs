using Entites.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contract;
using StoreApp.Infrastruckte.Extensions.extensions;
using StoreApp.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();   // biz ekledik
builder.Services.AddRazorPages(); // biz ekledik





//builder.Services.AddDbContext<RepositoryContext>(Option => // /// BU KISIM VER� BA�LANTISI BUNU BA�KA YERE TA�IDIK GERKEL� UNUTMA
//{
//    Option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")) ; 
//}
//);

builder.Services.ConfigureDbContext(builder.Configuration);  // yukardaki ba�lant� yerine ekledik ServiceExtensions




builder.Services.AddDistributedMemoryCache();  // otur y�netim /session
builder.Services.AddSession(Option =>{
    Option.Cookie.Name = "StorApp.Session";
    Option.IdleTimeout = TimeSpan.FromMinutes(10);
});// otur y�netim /session
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>(); // otur y�netim i�in devam ediyor


builder.Services.AddScoped<IRepositoryManger,RepositoryManager>();
builder.Services.AddScoped<IProductRepository,PorductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
//yuakr�daki 3 ifade riposiyory i�in 

builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IOrderService,OrderManager>();
//yuakr�daki 3 ifade services i�in 

builder.Services.AddScoped<Cart>(c=> SessionCart.GetCart(c));  // model deki kart� ekledik //ilk addsingletion yaptm��t�k sonra otur y�netim y�z�nde de�i�tirdik 

builder.Services.AddAutoMapper(typeof(Program)); // dto ekledik onun i�in package y�kledikten sonra kullan�yoruz


var app = builder.Build();
app.UseStaticFiles();  // static dosyalar� kullan
app.UseSession(); // // otur y�netim /session kulanmak i�in 

app.UseHttpsRedirection(); // biz ekLED�K
app.UseRouting();  // a��a��daki �al��s�n diye ekledik 



app.UseEndpoints(endpoints => {


    endpoints.MapAreaControllerRoute(
       name: "Admin",
       areaName: "Admin",
       pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"

   );
    endpoints.MapControllerRoute(   // biz projenin ba��nda ekledik  // bu ilk ba�ta bir ekran a��ls�n diye yapt�k ama zamanla gni�licek
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages(); // biz ekledik
});

app.ConfigureAndCheckMigration();    // bu migrations lar�n otomatik yap�lmas�n� sa�l�cak kodunu extensoin k�sam�nda yazd�k




app.Run();
