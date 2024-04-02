using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool truckChanges);  //hepsini getir

        T? FindByCondition(Expression<Func<T,bool>> expression, bool truckChanges); // bir adet getir


        void create(T entity);   // ekle

        void Remove(T entity);

        void Update(T entity);


    }
}
