using StarTrack.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTrack.Core.EF6;
using StarTrack.Core.Models;

namespace StarTrack.Core.Repositories
{
    public class UserRepository : IUser
    {
        private readonly DataBase _db;

        public UserRepository(DataBase db)
        {
            _db = db;
        }

        public UserRepository() : this(new DataBase())
        {

        }

        public void CreateUser(string username, string password)
        {
            _db.Users.Add(new User() { Login = username, Password = password });
            _db.SaveChanges();
        }

        public int? GetUserId(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (user != null)
            {
                return user.Id;
            }
            return null;
        }
    }
}
