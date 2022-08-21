using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcers.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _prodcutDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal prodcutDal, ICategoryService categoryService)
        {
            _prodcutDal = prodcutDal;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            IResult result = BusinessRules.Run(CheckIfProductCountOfProductNameCorrect(product.ProductName), CheckIfProductCountOfCategoryCorrect(product.CategoryId));
            if (result != null)
            {
                return result;
            }

            _prodcutDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);

            // ValidationTool.Validation(new ProductValidator(),product);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new DataResult<List<Product>>(_prodcutDal.GetAll(), true, "Ürünler geriye döndü.");
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_prodcutDal.GetAll(p=>p.CategoryId.Equals(categoryId)));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_prodcutDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_prodcutDal.GetAll(p => p.UnitPrice>min && p.UnitPrice<max));
        }

        public IDataResult<List<Product>> GetByUnitPrice(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>( _prodcutDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            else
            {
                _prodcutDal.Update(product);
                return new SuccessResult("Ürün güncellendi.");
            }
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _prodcutDal.GetAll(p => p.CategoryId == categoryId).Count();  
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();

        }
        private IResult CheckIfProductCountOfProductNameCorrect(string productName)
        {
            var result = _prodcutDal.GetAll(p => p.ProductName == productName).Count();
            if (result >1)
            {
                return new ErrorResult(Messages.ProductCountOfProductNameError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll().Data.Count();
            if (result >= 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
