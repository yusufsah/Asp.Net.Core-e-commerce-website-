using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IOrderService
    {
        IQueryable<Order> Orders { get; }

        Order? GetOneOder(int id);

        void Complete(int id);

        void SaveOrder(Order order);

        int NumberOfInProcess { get; }
    }
}
