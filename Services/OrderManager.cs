using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderManager : IOrderService
    {

        private readonly IRepositoryManger _manager;

        public OrderManager(IRepositoryManger manager)
        {
            _manager = manager;
        }



        /// <summary>
        /// ////////////////////////////////////////////////////////
        /// </summary>



        public IQueryable<Order> Orders => _manager.Order.Orders;

        public int NumberOfInProcess => _manager.Order.NumberOfInProcess;

        public void Complete(int id)
        {
            _manager.Order.Complete(id);
            _manager.save();
        }

        public Order? GetOneOder(int id)
        {
            return _manager.Order.GetOneOder(id);
        }

        public void SaveOrder(Order order)
        {
            _manager.Order.SaveOrder(order);
        }
    }
}
