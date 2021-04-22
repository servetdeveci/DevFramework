using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using DevFramework.Northwind.Entities.ComplexType;
using System.Collections.Generic;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
       
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(p => p.UserName == userName & p.Password == password);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
