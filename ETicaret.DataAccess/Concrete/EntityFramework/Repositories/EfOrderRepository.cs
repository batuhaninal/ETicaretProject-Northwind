using Core.DataAccess.Concrete.EntityFramework;
using ETicaret.DataAccess.Abstract;
using ETicaret.DataAccess.Concrete.EntityFramework.Contexts;
using ETicaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfOrderRepository : EfEntityRepositoryBase<Order, NorthwindContext>, IOrderRepository
    {
    }
}
