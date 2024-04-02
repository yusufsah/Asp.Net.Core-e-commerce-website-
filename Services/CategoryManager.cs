using Entites.Models;
using Repositories.Contracts;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{


    public class CategoryManager : ICategoryService
    {

        private readonly IRepositoryManger _manager;

        public CategoryManager(IRepositoryManger manager)
        {
            _manager = manager;
        }



        /// ////////////BU KISMI REPOSİTORYS  DEKİ FONKSİYONLARI KULLANMAK İÇİN
        IEnumerable<Category> ICategoryService.GetAllCategories(bool trackChanges)
        {
           return _manager.Category.FindAll(trackChanges);
        }

         

    }
}
