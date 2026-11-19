using Ribbons.Users.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users.Data
{
    [Table(TableNames.UserPassword)]
    public class UserPassword
    {
        [Column("user_id")]
        [Key]
        public long UserId { get; set; }

        [Column("password_salt")]
        [MaxLength(64)]
        public byte[] PasswordSalt { get; set; }

        [Column("password_hash")]
        [MaxLength(64)]
        public byte[] PasswordHash { get; set; }

        [Column("password_iterations")]
        [Required]
        public int PasswordIterations { get; set; }

        public User User { get; set; }
    }
}