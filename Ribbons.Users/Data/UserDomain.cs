using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users.Data
{
    /// <summary>
    /// <see cref="UserDomain"/> is intended create user scoping.
    /// For example, if the application has multiple organizations, each organization would be assigned one <see cref="UserDomain"/>.
    /// Each <see cref="UserDomain"/> will have its own collection of unique users. This behavior would allow username reuse across multiple organization accounts.
    /// The <see cref="UserDomain"/> is not mandatory. Some applications will not require user scoping of this fashion, in which case <see cref="User.UserDomainId"/> will be null
    /// </summary>
    [Table("t_user_domain")]
    [Index(nameof(DomainName), IsUnique = true)]
    public class UserDomain
    {
        [Column("user_domain_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserDomainId { get; set; }

        [Column("domain_name")]
        [Required]
        [StringLength(255)]
        public string DomainName { get; set; }

        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }

        [Column("created_date")]
        [Required]
        public DateTime CreatedDate { get; set; }

        public ICollection<User> Users { get; set; }
    }
}