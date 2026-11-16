using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Constants;
using Ribbons.Users.Data;
using Ribbons.Users.Model;
using Ribbons.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ribbons.Users
{
    public sealed class UserManager : IUserManager
    {
        private UserDb UserDb { get; }

        public UserManager(IUserDbProvider userDbProvider)
        {
            UserDb = userDbProvider.GetDatabase();
        }

        public async Task<CreateUserDomainResponse> CreateUserDomainAsync(CreateUserDomainRequest request)
        {
            try
            {
                if (!request.TryValidateObject(out List<ValidationError> validationErrors))
                {
                    return new()
                    {
                        Status = CreateUserDomainStatus.Invalid,
                        Message = $"Failed to create user domain. {validationErrors.Count} validation error(s) detected",
                        ValidationErrors = validationErrors
                    };
                }

                if (await UserDb.UserDomains.AnyAsync(x => x.DomainName == request.DomainName))
                {
                    return new()
                    {
                        Status = CreateUserDomainStatus.Duplicate,
                        Message = $"{request.DomainName} is already in use"
                    };
                }

                UserDomain userDomain = new()
                {
                    DomainName = request.DomainName,
                    Description = request.Description,
                    CreatedDate = DateTime.Now
                };

                await UserDb.AddAsync(userDomain);
                await UserDb.SaveChangesAsync();

                return new()
                {
                    Status = CreateUserDomainStatus.Ok,
                    Message = $"User domain {userDomain.DomainName} created"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Status = CreateUserDomainStatus.Error,
                    Message = ex.Message
                };
            }
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            try
            {
                if (!request.TryValidateObject(out List<ValidationError> validationErrors))
                {
                    return new()
                    {
                        Status = CreateUserStatus.Invalid,
                        Message = $"Failed to create user. {validationErrors.Count} validation error(s) detected",
                        ValidationErrors = validationErrors
                    };
                }

                string domainName = request.DomainName.IsNullOrWhiteSpace() ? ReservedUserDomains.Default : request.DomainName;

                UserDomain userDomain = await UserDb.UserDomains.FirstOrDefaultAsync(x => x.DomainName == domainName);

                if (userDomain == null)
                {
                    return new()
                    {
                        Status = CreateUserStatus.UserDomainNotFound,
                        Message = $"Failed to create user. Domain {domainName} not found"
                    };
                }

                if (await UserDb.Users.AnyAsync(x => x.UserDomainId == userDomain.UserDomainId && x.UserName == request.UserName))
                {
                    return new()
                    {
                        Status = CreateUserStatus.Duplicate,
                        Message = $"Failed to create user. User {request.UserName} is already exists for domain {userDomain.DomainName}"
                    };
                }

                User user = new()
                {
                    UserDomainId = userDomain.UserDomainId,
                    UserName = request.UserName,
                    CreatedDate = DateTime.Now
                };

                await UserDb.AddAsync(user);
                await UserDb.SaveChangesAsync();

                return new()
                {
                    Status = CreateUserStatus.Ok,
                    Message = $"User {user.UserName} created under domain {userDomain.DomainName}"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Status = CreateUserStatus.Error,
                    Message = ex.Message
                };
            }
        }
    }
}