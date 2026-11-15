using System.Threading.Tasks;

namespace Ribbons.Users
{
    public interface IUserManager
    {
        Task CreateUserDomainAsync(string domainName, string description);
    }
}