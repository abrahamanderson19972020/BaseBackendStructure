using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

ProductManager productManager = new ProductManager(new InMemoryProductDal());
List<Product> products = productManager.GetAll();
foreach(Product product in products)
{
    Console.WriteLine($"Product{product.ProductId}: Name= {product.ProductName} with price {product.UniPrice} in stock in numbers {product.UnitsInStock}");
    Console.WriteLine("-------------------------------------------------------------------------------------------");
}