using ETicaret.Business.Abstract;
using ETicaret.DataAccess.Abstract;
using ETicaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryDal)
        {
            _categoryRepository = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryRepository.Get(x=>x.CategoryId == categoryId);
        }
    }
}
