using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users.Data
{
    [Table(TableNames.UserSession)]
    [Index(nameof(UserId))]
    [Index(nameof(CreatedDate))]
    [Index(nameof(SessionIdentifier))]
    public class UserSession
    {
        [Column("user_session_id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserSessionId { get; set; }

        [Column("user_id")]
        [Required]
        public long UserId { get; set; }

        [Column("created_date")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }

        [Column("session_identifier")]
        [Required]
        [StringLength(64)]
        public string SessionIdentifier { get; set; }

        [Column("session_token_salt")]
        [MaxLength(64)]
        public byte[] SessionTokenSalt { get; set; }

        [Column("session_token_hash")]
        [MaxLength(64)]
        public byte[] SessionTokenHash { get; set; }

        [Column("session_token_iterations")]
        public int SessionTokenIterations { get; set; }

        public virtual User User { get; set; }
    }
}
