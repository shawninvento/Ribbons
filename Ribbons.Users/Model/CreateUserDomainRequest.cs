using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Model
{
    public sealed class CreateUserDomainRequest
    {
        [Required(ErrorMessage = "Domain name is required")]
        [RegularExpression(@"^[A-Za-z0-9_-]+$", ErrorMessage = "{0} may contain only letters, numbers, underscores, and dashes.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Domain name must be between {2} and {1} characters long")]
        public string DomainName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}