using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
     class UserInfoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserInfoContext() : base(Properties.Settings1.Default.DbConnect) // add property settings to project
        {
        }
    }
}
