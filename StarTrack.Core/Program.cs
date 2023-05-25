using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTrack.Core.EF6;
using StarTrack.Core.Models;
using StarTrack.Core.Services;

namespace StarTrack.Core
{
    internal class Program
    {

            static void Main(string[] args)
        {
            var _userDataProvider = new UserDataProvider();
            _userDataProvider.CreateUser("admin", "root");

        }
    }
}
