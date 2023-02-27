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
    public class CustomerManager : ICustomerService
    {
         private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public Customer GetCustomer(string customerId)
        {
           return _customerDal.Get(cus => cus.CustomerId == customerId);
        }

        public List<Customer> GetCustomers()
        {
            return _customerDal.GetAll();
        }
    }
}
