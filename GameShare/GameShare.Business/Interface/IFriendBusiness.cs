using GameShare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Business.Interface
{
    public interface IFriendBusiness
    {
        IEnumerable<Friend> List();
        Friend GetBy(int? id);
        void Create(Friend friend);
        void Delete(int? id);
        void Edit(Friend friend);
        void Dispose();
    }
}
