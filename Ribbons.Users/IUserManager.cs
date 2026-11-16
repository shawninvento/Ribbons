using Ribbons.Users.Model;
using System.Threading.Tasks;

namespace Ribbons.Users
{
    public interface IUserManager
    {
        Task<CreateUserDomainResponse> CreateUserDomainAsync(CreateUserDomainRequest request);
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
    }
}