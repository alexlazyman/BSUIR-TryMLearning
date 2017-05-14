using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("User")]
    public class UserDbEntity : IDbEntity
    {
        int IDbEntity.Id
        {
            get => UserId;
            set => UserId = value;
        }

        [Key]
        public int UserId { get; set; }

        [MaxLength(128)]
        public string UserName { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(128)]
        public string PasswordHash { get; set; }
    }
}
