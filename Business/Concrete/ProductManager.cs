using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
        public List<Product> GetAll()
        {
          return  _prodcutDal.GetAll();
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
    }
}
