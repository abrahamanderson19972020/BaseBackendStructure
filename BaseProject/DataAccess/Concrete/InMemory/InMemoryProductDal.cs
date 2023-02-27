using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>() {
                new Product { ProductId = 1,CategoryId = 1,ProductName = "Computer", UnitPrice = 3211.34M, UnitsInStock = 32 },
                new Product { ProductId = 2,CategoryId = 1,ProductName = "Gaming Screen", UnitPrice = 2892, UnitsInStock = 65 },
                new Product { ProductId = 3,CategoryId = 1,ProductName = "Mouse", UnitPrice = 65, UnitsInStock = 875 },
                new Product { ProductId = 4,CategoryId = 2,ProductName = "Washing Machine", UnitPrice = 6544, UnitsInStock = 2 },
                new Product { ProductId = 5,CategoryId = 2,ProductName = "Drying Machine", UnitPrice = 7611.34M, UnitsInStock = 18 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (productToDelete != null)
            {
                _products.Remove(productToDelete);
            }
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product Get(int productId)
        {
            Product product = _products.Find(p => p.ProductId == productId);
            if (product != null) return product;
            else return new Product();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.Find(x => x.ProductId == product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.UnitsInStock = product.UnitsInStock;
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
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
