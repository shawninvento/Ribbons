using Microsoft.EntityFrameworkCore;
using Ribbons.Cryptography;
using Ribbons.Users.Constants;
using Ribbons.Users.Data;
using Ribbons.Users.Db;
using Ribbons.Users.Model;
using Ribbons.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ribbons.Users
{
    public sealed class UserManager : IUserManager
    {
        private const int Iterations = 600000;
        private UserDb UserDb { get; }

        public UserManager(IUserDbProvider userDbProvider)
        {
            UserDb = userDbProvider.GetDatabase();
        }

        /// <summary>
        /// Creates a new user domain
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateUserDomainResponse> CreateUserDomainAsync(CreateUserDomainRequest request)
        {
            try
            {
                if (!request.TryValidateObject(out List<ValidationError> validationErrors))
                {
                    return new(CreateUserDomainStatus.Invalid, $"Failed to create user domain. {validationErrors.Count} validation errors(s) detected", validationErrors);
                }

                if (await UserDb.UserDomains.AnyAsync(x => x.DomainName == request.DomainName))
                {
                    return new(CreateUserDomainStatus.Duplicate, $"Failed to create user domain. {request.DomainName} is already in use");
                }

                UserDomain userDomain = new()
                {
                    DomainName = request.DomainName,
                    Description = request.Description,
                    CreatedDate = DateTime.Now
                };

                await UserDb.AddAsync(userDomain);
                await UserDb.SaveChangesAsync();

                return new(CreateUserDomainStatus.Ok, $"User domain {userDomain.DomainName} created");
            }
            catch (Exception ex)
            {
                return new(CreateUserDomainStatus.Error, ex.Message);
            }
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            try
            {
                if (!request.TryValidateObject(out List<ValidationError> validationErrors))
                {
                    return new(CreateUserStatus.Invalid, $"Failed to create user. {validationErrors.Count} validation error(s) detected", validationErrors);
                }

                string domainName = request.DomainName.IsNullOrWhiteSpace() ? ReservedUserDomains.Default : request.DomainName;

                UserDomain userDomain = await UserDb.UserDomains.FirstOrDefaultAsync(x => x.DomainName == domainName);

                if (userDomain == null)
                {
                    return new(CreateUserStatus.UserDomainNotFound, $"Failed to create user. Domain {domainName} not found");
                }

                if (await UserDb.Users.AnyAsync(x => x.UserDomainId == userDomain.UserDomainId && x.UserName == request.UserName))
                {
                    return new(CreateUserStatus.Duplicate, $"Failed to create user. User {request.UserName} is already exists for domain {userDomain.DomainName}");
                }

                request.Password.ComputePbkdf2(600000, out byte[] passwordSalt, out byte[] passwordHash);

                User user = new()
                {
                    UserDomainId = userDomain.UserDomainId,
                    UserName = request.UserName,
                    CreatedDate = DateTime.Now,
                    UserPassword = new()
                    {
                        PasswordSalt = passwordSalt,
                        PasswordHash = passwordHash,
                        PasswordHashIterations = Iterations
                    }
                };

                await UserDb.AddAsync(user);
                await UserDb.SaveChangesAsync();

                return new(CreateUserStatus.Ok, $"User {user.UserName} created under domain {userDomain.DomainName}");
            }
            catch (Exception ex)
            {
                return new(CreateUserStatus.Error, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AuthenticateUserResponse> AuthenticateUserAsync(AuthenticateUserRequest request)
        {
            try
            {
                if (!request.TryValidateObject(out List<ValidationError> validationErrors))
                {
                    return new(AuthenticateUserStatus.Invalid, $"Failed to authenticate user. {validationErrors.Count} validation error(s) detected", validationErrors);
                }

                string domainName = request.DomainName.IsNullOrWhiteSpace() ? ReservedUserDomains.Default : request.DomainName;
                
                User user = await UserDb.Users
                    .Include(x => x.UserPassword)
                    .FirstOrDefaultAsync(x => x.UserName == request.UserName && x.UserDomain.DomainName == domainName);

                if (user == null)
                {
                    return new(AuthenticateUserStatus.CredentialsInvalid, $"Failed to authenticate user. Credentials invalid");
                }

                if (!request.Password.TryValidatePbkdf2(user.UserPassword.PasswordHashIterations, user.UserPassword.PasswordSalt, user.UserPassword.PasswordHash))
                {
                    return new(AuthenticateUserStatus.CredentialsInvalid, $"Failed to authenticate user. Credentials invalid");
                }

                return new(AuthenticateUserStatus.Ok, "User authenticated");
            }
            catch (Exception ex)
            {
                return new(AuthenticateUserStatus.Error, ex.Message);
            }
        }

        public Task<string> CreateUserSessionAsync(long userId)
        {
            throw new NotImplementedException();
        }
    }
}