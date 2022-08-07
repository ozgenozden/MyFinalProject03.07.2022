using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _prodcutDal;
        public ProductManager(IProductDal prodcutDal)
        {
            _prodcutDal = prodcutDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            else
            {
                _prodcutDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
           
        }

        public IDataResult2 GetAll()
        {
            return new DataResult2(_prodcutDal.GetAll(), "sfdfsdf", true);
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _prodcutDal.GetAll(p=>p.CategoryId.Equals(categoryId));
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _prodcutDal.GetAll(p => p.UnitPrice>min && p.UnitPrice<max);
        }

        public List<Product> GetByUnitPrice(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _prodcutDal.GetProductDetails();
        }
    }
}
