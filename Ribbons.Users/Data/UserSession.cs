using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Data.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users.Data
{
    [Table(TableNames.UserSession)]
    [Index(nameof(UserId))]
    [Index(nameof(CreatedDate))]
    public class UserSession
    {
        [Column(ColumnNames.UserSessionId)]
        [Key]
        [MaxLength(ColumnConstraints.UserSessionIdLength)]
        public byte[] UserSessionId { get; set; }

        [Column(ColumnNames.UserId)]
        [Required]
        public long UserId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ExpiryDate)]
        public DateTime? ExpiryDate { get; set; }

        public virtual User User { get; set; }
    }
}
