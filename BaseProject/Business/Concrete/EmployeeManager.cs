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
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.ItemAdded);
        }
        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.ItemRemoved);
        }

        public IDataResult<Employee> GetEmployee(int employeeId)
        {
            var result = _employeeDal.Get(emp => emp.EmployeeId == employeeId);
            return new SuccessDataResult<Employee>(result);
        }

        public IDataResult<List<Employee>> GetEmployees()
        {
            var result = _employeeDal.GetAll();
            return new SuccessDataResult<List<Employee>>(result);
        }

  
    }
}
