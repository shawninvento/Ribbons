using Microsoft.Extensions.Options;
using Ribbons.Data;

namespace Ribbons.Users.Db
{
    public sealed class UserDbConfig : DatabaseConfig, IOptions<UserDbConfig>
    {
        public UserDbConfig Value => this;
    }
}