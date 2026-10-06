using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public class UserDbSqlite : Database
    {
        public UserDbSqlite() : base(DatabaseEngine.Sqlite)
        {
        }
    }
}