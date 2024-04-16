using AutoMapper;
using Entites.Dtos;
using Entites.Models;
using Entites.RequestParameters;
using Repositories.Contracts;
using Services.Contract;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManger _manager;
        private readonly IMapper _mapper;      // burada mapper kullandık çünkü dto kullandık eğer dto kullanmasıak gerek yoktu

        public ProductManager(IRepositoryManger manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }




        /// ////////////BU KISMI REPOSİTORYS  DEKİ FONKSİYONLARI KULLANMAK İÇİN 

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);

        }
        
        /// //////////////////////////////////////////////////////////////////
        
        public Product? GetOneProduct(int id, bool trackChangrs)
        {
            var product = _manager.Product.GetOneProduct(id, trackChangrs);

            if(product is null)
            {
                throw new Exception("not found");     // burasyı istege bağlı yaptım 
            }
            else
            {
                return product;
            }
            
        }
        /// //////////////////////////////////////////////////////////////////

        public void createproduct(ProductDtosForinsertion productDto) // burası product ile yaptık sonra dto ekleyince değiştirdik
        {
            Product product = _mapper.Map<Product>(productDto); // buryı yukarda dto koyduk diye var yoksa  burayı yamaya gerek yoktu
     

            _manager.Product.createproduct(product);
            _manager.save();
        }



        ////////////////////////////////////////////////////////////////////

        public void UpdateOneProduct(ProductDtosForUpdate productDto)  // bu sarvis diğerlerinde ayrı bunu ripositorysi yapmadık direk  burada yadık //ve eskide product kullanıyordum ama dto ekliyince buna geçtik
        {

            //var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);
            //entity.ProductName = product.ProductName;
            //entity.Price = product.Price;
            //entity.categoryId = product.categoryId;  // buda dto eklenmedik hali 

            Product product = _mapper.Map<Product>(productDto);
            _manager.Product.UpadateOneProduct(product);
            


            _manager.save();

        }



        ////////////////////////////////////////////////////////////////////
        ///
        public void DeleteOneProduct(int id)
        {
            Product product = GetOneProduct(id, false) ?? new Product();  // 1 adet ürün aldık
            if(product is not null)
            {

                _manager.Product.DeleteOneProduct(product);
                _manager.save();
            }
        }


        //////////////////////////////////////////////////////////////////////////
        ///
        public ProductDtosForUpdate GetOneProductForUpdate(int id, bool truckChanges)
        {
            var product = _manager.Product.GetOneProduct(id,truckChanges);
            var productdto = _mapper.Map<ProductDtosForUpdate>(product);

            return productdto;

        }
        
        //// /////////////////////////////////////////////////////////////////////
      
        public IQueryable<Product> GetAllshowcaseProduct(bool trackChanges)
        {
            var product = _manager.Product.GetAllshowcaseProduct(trackChanges);

            return product;
        }



       
        ///////////////////////////////////////////////////////////////////////////////
       

        public IEnumerable<Product> GetAllProductwithDetails(ProductRequestParameters p)
        {
            return _manager.Product.GetAllProductwithDetails(p);
        }


        /// ////////////////////////////////////////////////////////

        public IEnumerable<Product> GetlastestProducts(int n, bool trackChanges) // bunun tanı için repository ye inmedim
        {
            return _manager.Product.FindAll(trackChanges)
                                     .OrderByDescending(prd=>prd.ProductId).Take(n);
        }

      


    }
}
