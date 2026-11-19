using Ribbons.Data;

namespace Ribbons.Users.Db
{
    public class UserDbMySql : UserDb
    {
        public UserDbMySql() : base(DatabaseEngine.MySql) { }
    }
}