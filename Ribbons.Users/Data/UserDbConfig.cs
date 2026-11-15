using Microsoft.Extensions.Options;
using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public sealed class UserDbConfig : DatabaseConfig, IOptions<UserDbConfig>
    {
        public UserDbConfig Value => this;
    }
}