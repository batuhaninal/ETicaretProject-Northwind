using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validations.FluentValidation;
using Core.Entities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using ETicaret.Business.Abstract;
using ETicaret.Business.BusinessAspects.Autofac;
using ETicaret.Business.Constants;
using ETicaret.Business.ValidationRules.FluentValidation;
using ETicaret.DataAccess.Abstract;
using ETicaret.Entities.Concrete;
using ETicaret.Entities.DTOs;
using FluentValidation;
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
        private readonly ICategoryService _categoryService;

        public ProductManager(IProductRepository productDal, ICategoryService categoryService)
        {
            _productRepository = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Product entity)
        {
            //ValidationTool.Validate(new ProductValidator(), entity);
            var result = BusinessRules.Run(CheckIfProductNameExists(entity.ProductName), 
                CheckIfProductCountOfCategoryCorrect(entity.CategoryId),
                CheckIfCategoryLimitExceded());
            if (result == null)
            {
                _productRepository.Add(entity);

                return new SuccessResult(Messages.ProductAdded);
            }
            return result;
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 16)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll(x => x.CategoryId == categoryId));
        }

        [CacheAspect]
        [PerformanceAspect(5)]
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
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productRepository.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product entity)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productRepository.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string name)
        {
            var result = _productRepository.GetAll(x => x.ProductName == name).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll().Data.Count;
            if (result > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult AddTransactionalTest(Product entity)
        {
            Add(entity);
            if (entity.UnitPrice > 10)
            {
                throw new Exception("");
            }


            entity.ProductName += "Son eklenen";

            Add(entity);

            return null;
        }
    }
}
