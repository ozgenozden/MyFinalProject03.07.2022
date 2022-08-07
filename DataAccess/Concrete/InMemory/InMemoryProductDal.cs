﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{CategoryId=2,ProductId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{CategoryId=3,ProductId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{CategoryId=4,ProductId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{CategoryId=5,ProductId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            _products.Remove(_products.SingleOrDefault(x=>x.ProductId.Equals(product.ProductId)));
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {

            var updateProduct = _products.SingleOrDefault(x => x.ProductId.Equals(product.ProductId));
            updateProduct.CategoryId = product.CategoryId;
            updateProduct.ProductName = product.ProductName;
            updateProduct.UnitPrice = product.UnitPrice;
            updateProduct.UnitsInStock = product.UnitsInStock;


        }
        public List<Product> GetAllByCategory(int categoryId)
        {

            return _products.Where(x => x.CategoryId.Equals(categoryId)).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {

            return _products.Where(filter.Compile()).ToList();
        }

        public Product Get()
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
