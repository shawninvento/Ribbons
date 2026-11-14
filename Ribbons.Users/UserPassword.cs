using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table("t_user_password")]
    public class UserPassword
    {
        [Column("user_id")]
        [Key]
        public long UserId { get; set; }

        [Column("password_salt")]
        [MaxLength(512)]
        public byte[] PasswordSalt { get; set; }

        [Column("password_hash")]
        [MaxLength(512)]
        public byte[] PasswordHash { get; set; }
    }
}