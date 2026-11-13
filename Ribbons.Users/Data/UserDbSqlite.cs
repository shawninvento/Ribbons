using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public class UserDbSqlite : UserDb
    {
        public UserDbSqlite() : base(DatabaseEngine.Sqlite) { }
    }
}
