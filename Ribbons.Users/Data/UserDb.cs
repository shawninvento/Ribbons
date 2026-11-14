using Microsoft.EntityFrameworkCore;
using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public abstract class UserDb : Database
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserDomain> UserDomains { get; set; }

        protected UserDb(DatabaseEngine databaseEngine) : base(databaseEngine) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasIndex(x => new { x.UserDomainId, x.UserName })
                .IsUnique()
                .HasFilter(null);


            modelBuilder
                .HasOneToMany<UserDomain, User>(x => x.Users, x => x.UserDomain, x => x.UserDomainId);
        }
    }
}