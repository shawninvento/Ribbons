using Ribbons.Data;

namespace Ribbons.Users.Db
{
    public class UserDbMsSql : UserDb
    {
        public UserDbMsSql() : base(DatabaseEngine.MsSql) { }
    }
}