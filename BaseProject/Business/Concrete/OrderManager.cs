using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public List<Order> GetAllOrders()
        {
            return _orderDal.GetAll();
        }

        public Order GetOrder(int orderId)
        {
            return _orderDal.Get(order => order.OrderId == orderId);    
        }
    }
}
