using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using System;

namespace Ribbons.Users.Data
{
    public abstract class UserDb : Database
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserDomain> UserDomains { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }

        protected UserDb(DatabaseEngine databaseEngine) : base(databaseEngine) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasOneToMany<UserDomain, User>(x => x.Users, x => x.UserDomain, x => x.UserDomainId)
                .HasOneToOne<User, UserPassword>(x => x.UserPassword, x => x.User, x => x.UserId);

            modelBuilder
                .HasData(new UserDomain
                {
                    UserDomainId = 1,
                    DomainName = "default",
                    CreatedDate = DateTime.MinValue
                });
        }
    }
}