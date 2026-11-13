using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public abstract class UserDb : Database
    {
        protected UserDb(DatabaseEngine databaseEngine) : base(databaseEngine) { }
    }
}