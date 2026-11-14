using Ribbons.Data;
using Ribbons.Users;
using Ribbons.Users.Data;
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

            UserDb db = await dbProvider.GetDatabaseAsync();

            for (int i = 0; i < 100; i++)
            {
                User user = new()
                {
                    UserName = 0.ToString().PadLeft(10, '0'),
                    CreatedDate = DateTime.Now
                };

                db.Users.Add(user);
            }

            await db.SaveChangesAsync();
        }
    }
}