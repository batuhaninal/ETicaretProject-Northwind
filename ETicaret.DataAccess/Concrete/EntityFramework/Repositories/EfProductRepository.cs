using Core.DataAccess.Concrete.EntityFramework;
using ETicaret.DataAccess.Abstract;
using ETicaret.DataAccess.Concrete.EntityFramework.Contexts;
using ETicaret.Entities.Concrete;
using ETicaret.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfProductRepository : EfEntityRepositoryBase<Product, NorthwindContext>, IProductRepository
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };

                return result.ToList();
            }
        }
    }
}
