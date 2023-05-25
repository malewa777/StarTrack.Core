using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTrack.Core.Models;

namespace StarTrack.Core.EF6
{
    public class DataBase : DbContext
    {
        public DataBase() : base("DataBaseConnectionString")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
