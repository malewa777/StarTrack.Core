using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrack.Core.Abstracts
{
    public interface IUser
    {
        void CreateUser(string username, string password);
        int? GetUserId(string username, string password);
    }

    
}
