using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManger
    {

        IProductRepository Product { get; }

        ICategoryRepository Category { get; }


        IOrderRepository Order { get; }
        void save();
    }
}
