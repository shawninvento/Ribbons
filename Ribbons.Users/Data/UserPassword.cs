using Ribbons.Users.Data.Definitions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users.Data
{
    [Table(TableNames.UserPassword)]
    public class UserPassword
    {
        [Column(ColumnNames.UserId)]
        [Key]
        public long UserId { get; set; }

        [Column(ColumnNames.PasswordSalt)]
        [MaxLength(ColumnConstraints.PasswordSaltLength)]
        public byte[] PasswordSalt { get; set; }

        [Column(ColumnNames.PasswordHash)]
        [MaxLength(ColumnConstraints.PasswordHashLength)]
        public byte[] PasswordHash { get; set; }

        [Column(ColumnNames.PasswordHashIterations)]
        [Required]
        public int PasswordHashIterations { get; set; }

        public User User { get; set; }
    }
}