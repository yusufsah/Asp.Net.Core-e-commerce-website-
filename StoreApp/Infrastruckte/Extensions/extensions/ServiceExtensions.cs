using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Bson;
using Repositories;
using System.Configuration;

namespace StoreApp.Infrastruckte.Extensions.extensions
{
    public  static class ServiceExtensions
    {

        public static void ConfigureDbContext(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<RepositoryContext>(Option =>  // kısım veritabanı bağlantısı
            {
                Option.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            }
);

        }


    }
}
