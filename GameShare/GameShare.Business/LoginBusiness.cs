using System;
using GameShare.Business.Interface;
using GameShare.Entity.Entities;
using System.Linq;

namespace GameShare.Business
{
    public class LoginBusiness : ILoginBusiness
    {
        private GameShareEntities _dataContext;

        public LoginBusiness(GameShareEntities dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CheckAuth(User user)
        {
            var result = _dataContext.Users.Where(x => x.Username.Equals(user.Username) && 
                                                        x.Password.Equals(user.Password)).ToList();

            return result.Count > 0;
        }
    }
}
