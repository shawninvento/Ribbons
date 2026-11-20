using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Data.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users.Data
{
    [Table(TableNames.User)]
    [Index(nameof(UserDomainId))]
    [Index(nameof(UserName))]
    [Index(nameof(UserDomainId), nameof(UserName), IsUnique = true)]
    [Index(nameof(CreatedDate))]
    public class User
    {
        [Column(ColumnNames.UserId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [Column(ColumnNames.UserDomainId)]
        public long UserDomainId { get; set; }

        [Column(ColumnNames.UserName)]
        [Required]
        [StringLength(ColumnConstraints.UserNameLength)]
        public string UserName { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        public virtual UserDomain UserDomain { get; set; }
        public virtual UserPassword UserPassword { get; set; }
        public virtual ICollection<UserSession> UserSessions { get; set; }
    }
}