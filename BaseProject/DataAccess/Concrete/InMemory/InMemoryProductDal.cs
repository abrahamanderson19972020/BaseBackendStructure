using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Product { ProductId = 1,CategoryId = 1,ProductName = "Computer", UniPrice = 3211.34M, UnitsInStock = 32 },
                new Product { ProductId = 2,CategoryId = 1,ProductName = "Gaming Screen", UniPrice = 2892, UnitsInStock = 65 },
                new Product { ProductId = 3,CategoryId = 1,ProductName = "Mouse", UniPrice = 65, UnitsInStock = 875 },
                new Product { ProductId = 4,CategoryId = 2,ProductName = "Washing Machine", UniPrice = 6544, UnitsInStock = 2 },
                new Product { ProductId = 5,CategoryId = 2,ProductName = "Drying Machine", UniPrice = 7611.34M, UnitsInStock = 18 },
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

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product GetById(int productId)
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
                productToUpdate.UniPrice = product.UniPrice;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.UnitsInStock = product.UnitsInStock;
            }
        }
    }
}
