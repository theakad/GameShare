using GameShare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Business.Interface
{
    public interface IGameBusiness
    {
        IEnumerable<Game> List();
        Game GetBy(int? id);
        void Create(Game game);
        void Delete(int? id);
        void Edit(Game game);
        void Dispose();
        IEnumerable<Friend> GetFriendsOnGame();
    }
}
