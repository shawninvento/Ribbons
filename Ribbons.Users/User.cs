using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table("t_user")]
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(CreatedDate))]
    public class User
    {
        [Column("user_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [Column("user_name")]
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [Column("created_date")]
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}