using Business.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAllOrders();
        IDataResult<Order> GetOrder(int orderId);
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(Order order);
    }
}
