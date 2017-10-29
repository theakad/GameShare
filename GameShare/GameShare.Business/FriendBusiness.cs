using System;
using System.Collections.Generic;
using GameShare.Business.Interface;
using GameShare.Entity.Entities;
using System.Data.Entity;

namespace GameShare.Business
{
    public class FriendBusiness : IFriendBusiness
    {
        private GameShareEntities _dataContext;

        public FriendBusiness(GameShareEntities dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Friend friend)
        {
            _dataContext.Friends.Add(friend);
            _dataContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            Friend friend = GetBy(id);
            _dataContext.Friends.Remove(friend);
            _dataContext.SaveChanges();
        }

        public void Edit(Friend friend)
        {
            _dataContext.Entry(friend).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public Friend GetBy(int? id)
        {
            return _dataContext.Friends.Find(id);
        }

        public IEnumerable<Friend> List()
        {
            return _dataContext.Friends;
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
