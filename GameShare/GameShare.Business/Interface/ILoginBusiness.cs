using GameShare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Business.Interface
{
    public interface ILoginBusiness
    {
        bool CheckAuth(User user);
    }
}
