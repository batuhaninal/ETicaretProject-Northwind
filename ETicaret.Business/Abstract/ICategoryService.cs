using ETicaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);
    }
}
