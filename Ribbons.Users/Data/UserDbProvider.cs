using Microsoft.Extensions.Options;
using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public class UserDbProvider : DatabaseProvider<UserDb, UserDbConfig>
    {
        public UserDbProvider(IOptions<UserDbConfig> configuration) : base(configuration) { }

        protected override UserDb CreateInstance()
        {
            UserDb instance = Configuration.DatabaseEngine switch
            {
                DatabaseEngine.MsSql => new UserDbMsSql(),
                DatabaseEngine.MySql => new UserDbMySql(),
                DatabaseEngine.Npgsql => new UserDbNpgsql(),
                DatabaseEngine.Sqlite => new UserDbSqlite(),
                _ => throw new NotSupportedException()
            };

            return instance;
        }
    }
}
