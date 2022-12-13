using Core.DataAccess.Abstract;
using ETicaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DataAccess.Abstract
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
    }
}
