using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }



        /// <summary>
        /// ///////////////////////////////////////////////////////////

        public IQueryable<Order> Orders => _context.Orders.Include(o => o.Lines)
                                                              .ThenInclude(c1 => c1.product)
                                                              .OrderBy(o => o.shipped)
                                                              .ThenByDescending(o => o.OrderId);



        // gönderilmemiş siparişlerin numaarası
        public int NumberOfInProcess =>  _context.Orders.Count(o=>o.shipped.Equals(false));


        //

        public void Complete(int id)
        {
            var order = FindByCondition(o => o.OrderId.Equals(id),true);
            if(order is null)
                throw new Exception("sipariş bulunamadı");
 
            order.shipped = true;
            
            
        }

        //

        public Order? GetOneOder(int id)
        {
            return FindByCondition(o => o.OrderId.Equals(id),false);
        }
        //

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l=>l.product));
            if(order.OrderId == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }

    /// ///////////////////////////////////////////////////////



}

