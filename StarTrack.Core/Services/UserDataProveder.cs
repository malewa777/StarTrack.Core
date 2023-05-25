using StarTrack.Core.Abstracts;
using StarTrack.Core.Models;
using StarTrack.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrack.Core.Services
{
    public class UserDataProvider
    {
        IUser _userRepository;
        public UserDataProvider(IUser userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDataProvider() : this(new UserRepository())
        {

        }

        public void CreateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || password.Length <= 3)
            {
                return;
            }
            try
            {
                _userRepository.CreateUser(username, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public int? GetUserId(string login, string password)
        {
            return _userRepository.GetUserId(login.ToUpper(), password);
        }
    }
       
}

