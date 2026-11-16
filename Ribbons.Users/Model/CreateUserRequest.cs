using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Model
{
    public sealed class CreateUserRequest
    {
        [StringLength(255)]
        [RegularExpression(@"^[A-Za-z0-9_-]+$", ErrorMessage = "{0} may contain only letters, numbers, underscores, and dashes.")]
        public string DomainName { get; set; }

        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}