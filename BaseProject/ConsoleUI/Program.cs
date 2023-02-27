using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

ProductManager productManager = new ProductManager(new EfProductDal());

foreach (Product product in productManager.GetAllByCategoryId(4))
{
    Console.WriteLine($"Product{product.ProductId}: Name= {product.ProductName} with price {product.UnitPrice} in stock in numbers {product.UnitsInStock}");
    Console.WriteLine("-------------------------------------------------------------------------------------------");
}

OrderManager orderManager = new OrderManager(new EfOrderDal());
List<Order> allOrders = orderManager.GetAllOrders();
foreach(Order order in allOrders)
{
    Console.WriteLine($"Order Id: {order.OrderId}, Order Date: {order.OrderDate}, to city {order.ShipCity}, to customer with Id {order.CustomerId}");
}
Console.WriteLine("***************************Product Details********************************");
List<ProductDetailDto> productDetails = productManager.GetProductDetails();
foreach(ProductDetailDto productDetail in productDetails)
{
    Console.WriteLine($"Product{productDetail.ProductId}: Name= {productDetail.ProductName} with price {productDetail.UnitPrice} in stock in numbers {productDetail.UnitsInStock} belongs to Category {productDetail.CategoryName}");
    Console.WriteLine("-------------------------------------------------------------------------------------------");
}
