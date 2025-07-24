using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Propvivo_project.Models
{
    public class Roles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RoleId { get; set; }
        [Column("roleName")]
        [MaxLength(50)]
        public string? RoleName { get; set; } // Employee, Superior, Admin
        public ICollection<User> Users { get; set; }
    }
}
