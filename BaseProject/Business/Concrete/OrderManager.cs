using Business.Abstract;
using Business.Utilities.Constants;
using Business.Utilities.Results;
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

        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.ItemRemoved);
        }

        public IDataResult<List<Order>> GetAllOrders()
        {
            var result = _orderDal.GetAll();
            return new SuccessDataResult<List<Order>>(result);
        }

        public IDataResult<Order> GetOrder(int orderId)
        {
            var result = _orderDal.Get(order => order.OrderId == orderId);    
            return new SuccessDataResult<Order>(result);
        }       
    }
}
