using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {

        protected readonly RepositoryContext _context;


        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

      

        /// //////////////////////////////////////////////

        public IQueryable<T> FindAll(bool truckChanges)
        {
            return truckChanges
                ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();

            //if (trackChanges)    ALTARNATİF YAZILIŞINI YADIM 
            //{
            //    return _context.Set<T>();
            //}
            //else
            //{
            //    return _context.Set<T>().AsNoTracking();
            //}  
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool truckChanges)
        {
            return truckChanges
                ? _context.Set<T>().Where(expression).SingleOrDefault()
                : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }


        ////////////////////////////////////////////////////////////
        ///

        public void create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }



        // burada update uluşturmadık service katmanında olşturduk  
        //////////////////////////////////////////////////////////// dto ekledikten sonra burad oluşturduk

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
        }
    }

}
