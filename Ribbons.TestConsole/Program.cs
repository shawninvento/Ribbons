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

            CreateUserDomainResponse nullDomainName = await userManager.CreateUserDomainAsync(new CreateUserDomainRequest
            {
                DomainName = null
            });

            Console.WriteLine(nullDomainName.ToJson());

            CreateUserDomainResponse insufficientCharacters = await userManager.CreateUserDomainAsync(new CreateUserDomainRequest
            {
                DomainName = "1"
            });

            Console.WriteLine(insufficientCharacters.ToJson());

            CreateUserDomainResponse domainWithInvalidCharacters = await userManager.CreateUserDomainAsync(new CreateUserDomainRequest
            {
                DomainName = "!@#"
            });

            Console.WriteLine(domainWithInvalidCharacters.ToJson());

            CreateUserDomainResponse compositeErrors = await userManager.CreateUserDomainAsync(new CreateUserDomainRequest
            {
                DomainName = "1!"
            });

            Console.WriteLine(compositeErrors.ToJson());

            CreateUserResponse userInDefaultDomain = await userManager.CreateUserAsync(new CreateUserRequest
            {
                UserName = Guid.NewGuid().ToString(),
                Password = "ASD123!@#"
            });

            Console.WriteLine(userInDefaultDomain.ToJson());

            CreateUserResponse createDuplicateUser = await userManager.CreateUserAsync(new CreateUserRequest
            {
                UserName = "fixed",
                Password = "ASD123!@#"
            });

            Console.Write(createDuplicateUser.ToJson());
        }
    }
}