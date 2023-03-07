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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            var user = _userDal.Get(u =>u.Email == email);
            return user;
        }

        public List<OperationClaim> GetClaims(User user)
        {
           var claims =  _userDal.GetClaims(user);
            return claims;  
        }
    }
}
