using Entites.Dtos;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
    public static class ProductRepositoriesExtensions
    {
         public static IQueryable<Product> FilterByCategoryId(this IQueryable<Product> products,int? categoryId ) 
        {

            if(categoryId is null) 
            {
                return products;
            }
            else 
            {
                return products.Where(pr => pr.categoryId.Equals(categoryId));
            }

           
        }



        public static IQueryable<Product> FilterbySearch(this IQueryable<Product> products, String? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;

            else
                return products.Where(prd => prd.ProductName.ToLower()
                                           .Contains(searchTerm.ToLower()));

           

        }


        public static IQueryable<Product> FilterbyPrice(this IQueryable<Product> products, int minprice,int maxprice,bool isvelidprice)
        {
            if (isvelidprice)
                return products.Where(prd => prd.Price >= minprice && prd.Price <= maxprice);
            else 
                return products;
        
        
        }


        // yukardaki eklenti hepsi kategegriler veya fiyat arama yapmak için ürün sayfasında
        ///////////////////////////////



        /// burdakiler ise sayfa işlemleri  için
        /// 

        public static IQueryable<Product> topaginate(this IQueryable<Product> products,int pageNumber, int pageSize)
        { 
            return products.Skip(((pageNumber-1)*pageSize)).Take(pageSize);
        
        }
    }
}
