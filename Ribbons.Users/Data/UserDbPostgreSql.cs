using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public class UserDbPostgreSql : Database
    {
        public UserDbPostgreSql() : base(DatabaseEngine.PostgreSql)
        {
        }
    }
}