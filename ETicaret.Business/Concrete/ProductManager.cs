using Core.Utilities.Results;
using ETicaret.Business.Abstract;
using ETicaret.Business.Constants;
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

        public IResult Add(Product entity)
        {
            if (entity.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productRepository.Add(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 16)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll(x => x.CategoryId == categoryId));
        }

        public IDataResult<Product> GetById(int productId)
        {
            var result = _productRepository.Get(x => x.ProductId == productId);
            if (result == null)
            {
                return new ErrorDataResult<Product>("Verilen parametrede bir ürün bulunamadı.");
            }
            return new SuccessDataResult<Product>(result);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll(x=>x.UnitPrice >= min && x.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productRepository.GetProductDetails());
        }
    }
}
