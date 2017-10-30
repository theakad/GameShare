using GameShare.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShare.Entity.Entities;
using System.Data.Entity;

namespace GameShare.Business
{
    public class GameBusiness : IGameBusiness
    {
        private GameShareEntities _dataContext;

        public GameBusiness(GameShareEntities dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Game game)
        {
            _dataContext.Games.Add(game);
            _dataContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            Game game = GetBy(id);
            _dataContext.Games.Remove(game);
            _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public void Edit(Game game)
        {
            _dataContext.Entry(game).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public Game GetBy(int? id)
        {
            return _dataContext.Games.Find(id);
        }

        public IEnumerable<Game> List()
        {
            return _dataContext.Games;
        }

        public IEnumerable<Friend> GetFriendsOnGame()
        {
            return _dataContext.Friends;
        }
    }
}
