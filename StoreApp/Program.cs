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





//builder.Services.AddDbContext<RepositoryContext>(Option => // /// BU KISIM VERÝ BAÐLANTISI BUNU BAÞKA YERE TAÞIDIK GERKELÝ UNUTMA
//{
//    Option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")) ; 
//}
//);

builder.Services.ConfigureDbContext(builder.Configuration);  // yukardaki baðlantý yerine ekledik ServiceExtensions




builder.Services.AddDistributedMemoryCache();  // otur yönetim /session
builder.Services.AddSession(Option =>{
    Option.Cookie.Name = "StorApp.Session";
    Option.IdleTimeout = TimeSpan.FromMinutes(10);
});// otur yönetim /session
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>(); // otur yönetim için devam ediyor


builder.Services.AddScoped<IRepositoryManger,RepositoryManager>();
builder.Services.AddScoped<IProductRepository,PorductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
//yuakrýdaki 3 ifade riposiyory için 

builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IOrderService,OrderManager>();
//yuakrýdaki 3 ifade services için 

builder.Services.AddScoped<Cart>(c=> SessionCart.GetCart(c));  // model deki kartý ekledik //ilk addsingletion yaptmýþtýk sonra otur yönetim yüzünde deðiþtirdik 

builder.Services.AddAutoMapper(typeof(Program)); // dto ekledik onun için package yükledikten sonra kullanýyoruz


var app = builder.Build();
app.UseStaticFiles();  // static dosyalarý kullan
app.UseSession(); // // otur yönetim /session kulanmak için 

app.UseHttpsRedirection(); // biz ekLEDÝK
app.UseRouting();  // aþþaðýdaki çalýþsýn diye ekledik 



app.UseEndpoints(endpoints => {


    endpoints.MapAreaControllerRoute(
       name: "Admin",
       areaName: "Admin",
       pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"

   );
    endpoints.MapControllerRoute(   // biz projenin baþýnda ekledik  // bu ilk baþta bir ekran açýlsýn diye yaptýk ama zamanla gniþlicek
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages(); // biz ekledik
});

app.ConfigureAndCheckMigration();    // bu migrations larýn otomatik yapýlmasýný saðlýcak kodunu extensoin kýsamýnda yazdýk




app.Run();
