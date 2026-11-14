using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users.Data
{
    [Table("t_user")]
    [Index(nameof(UserDomainId))]
    [Index(nameof(UserName))]
    [Index(nameof(UserDomainId), nameof(UserName), IsUnique = true)]
    [Index(nameof(CreatedDate))]
    public class User
    {
        [Column("user_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [Column("user_domain_id")]
        public long UserDomainId { get; set; }

        [Column("user_name")]
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [Column("created_date")]
        [Required]
        public DateTime CreatedDate { get; set; }

        public UserDomain UserDomain { get; set; }
        public UserPassword UserPassword { get; set; }
    }
}