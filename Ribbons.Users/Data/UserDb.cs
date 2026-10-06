using Microsoft.EntityFrameworkCore;
using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public abstract class UserDb : Database
    {
        public DbSet<User> Users { get; set; }

        protected UserDb(DatabaseEngine databaseEngine) : base(databaseEngine) { }
    }
}