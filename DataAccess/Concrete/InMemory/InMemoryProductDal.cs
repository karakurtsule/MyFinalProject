using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products = new List<Product> { };

        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId = 1, CategoryId = 1, ProductName = "masa", UnitPrice = 500, UnitsInStock = 5},
                new Product{ProductId = 2, CategoryId = 1, ProductName = "sandalye", UnitPrice = 120, UnitsInStock = 14},
                new Product{ProductId = 3, CategoryId = 1, ProductName = "kitaplık", UnitPrice = 3510, UnitsInStock = 56},
                new Product{ProductId = 4, CategoryId = 2, ProductName = "lambader", UnitPrice = 240, UnitsInStock = 23},
                new Product{ProductId = 5, CategoryId = 2, ProductName = "vazo", UnitPrice = 75, UnitsInStock = 0}
            };

        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            var deleteItem = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(deleteItem);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }

        public void Update(Product product)
        {
            var updateItem = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            updateItem.ProductId = product.ProductId;
            updateItem.ProductName = product.ProductName;
            updateItem.UnitPrice = product.UnitPrice;
            updateItem.UnitsInStock = product.UnitsInStock;
            updateItem.CategoryId = product.CategoryId;
        }
    }
}
