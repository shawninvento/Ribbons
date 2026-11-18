using Ribbons.Data;
using Ribbons.Users;
using Ribbons.Users.Data;
using Ribbons.Users.Model;
using System;
using System.Threading.Tasks;

namespace Ribbons.TestConsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            UserDbConfig dbConfig = new()
            {
                DatabaseEngine = DatabaseEngine.MsSql,
                ConnectionString = "server=localhost;database=ribbons_user;trustservercertificate=true;integrated security=true"
            };

            IUserDbProvider dbProvider = new UserDbProvider(dbConfig);
            
            await dbProvider.MigrateAsync();

            IUserManager userManager = new UserManager(dbProvider);

            CreateUserResponse user = await userManager.CreateUserAsync(new CreateUserRequest
            {
                DomainName = "default",
                UserName = "admin",
                Password = "ASD123!@#"
            });

            Console.WriteLine(user.ToJson());
        }
    }
}