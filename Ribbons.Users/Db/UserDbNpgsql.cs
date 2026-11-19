using Ribbons.Data;

namespace Ribbons.Users.Db
{
    public class UserDbNpgsql : UserDb
    {
        public UserDbNpgsql() : base(DatabaseEngine.Npgsql) { }
    }
}