using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        void Update(User user); 
        void Delete(User user);
        User GetByMail(string email);
        List<User> GetAllUsers();
    }
}
