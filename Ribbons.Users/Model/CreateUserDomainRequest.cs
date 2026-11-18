using Ribbons.Users.Constants;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Model
{
    public sealed class CreateUserDomainRequest
    {
        [Required]
        [RegularExpression(DataConstraints.DomainNamePattern)]
        [StringLength(DataConstraints.DomainNameMaxLength, MinimumLength = DataConstraints.DomainNameMinLength)]
        public string DomainName { get; set; }

        [StringLength(DataConstraints.DescriptionMaxLength)]
        public string Description { get; set; }
    }
}