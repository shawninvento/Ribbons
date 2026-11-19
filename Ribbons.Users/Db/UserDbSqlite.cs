using Ribbons.Data;

namespace Ribbons.Users.Db
{
    public class UserDbSqlite : UserDb
    {
        public UserDbSqlite() : base(DatabaseEngine.Sqlite) { }
    }
}
