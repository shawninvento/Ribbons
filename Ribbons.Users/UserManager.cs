using Ribbons.Users.Data;
using System;
using System.Threading.Tasks;

namespace Ribbons.Users
{
    public sealed class UserManager : IUserManager
    {
        private UserDb UserDb { get; }

        public UserManager(IUserDbProvider userDbProvider)
        {
            UserDb = userDbProvider.GetDatabase();
        }

        public async Task CreateUserDomainAsync(string domainName, string description = null)
        {
            UserDomain userDomain = new()
            {
                DomainName = domainName,
                Description = description,
                CreatedDate = DateTime.Now
            };

            await UserDb.AddAsync(userDomain);
            await UserDb.SaveChangesAsync();
        }
    }
}