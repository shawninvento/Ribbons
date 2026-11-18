using Ribbons.Users.Constants;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Model
{
    public sealed class CreateUserRequest
    {
        [StringLength(DataConstraints.DomainNameMaxLength)]
        [RegularExpression(DataConstraints.DomainNamePattern, ErrorMessage = "domain_name_invalid_format")]
        public string DomainName { get; set; }

        [Required]
        [StringLength(DataConstraints.UserNameMaxLength, MinimumLength = DataConstraints.UserNameMinLength)]
        [RegularExpression(DataConstraints.UserNamePattern)]
        public string UserName { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string Password { get; set; }
    }
}
