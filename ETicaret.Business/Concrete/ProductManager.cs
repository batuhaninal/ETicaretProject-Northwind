using ETicaret.Business.Abstract;
using ETicaret.DataAccess.Abstract;
using ETicaret.Entities.Concrete;
using ETicaret.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productDal)
        {
            _productRepository = productDal;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _productRepository.GetAll(x => x.CategoryId == categoryId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productRepository.GetAll(x=>x.UnitPrice >= min && x.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productRepository.GetProductDetails();
        }
    }
}
