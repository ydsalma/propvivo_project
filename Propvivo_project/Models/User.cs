using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Propvivo_project.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Column("email")]
        [MaxLength(100)]
        public string Email { get; set; }
        [Column("passwordHash")]
        [MaxLength(255)]
        public string PasswordHash { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; } = true;
        [Column("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("Roles")]
        [Column("roleId")]
        public int RoleId { get; set; }
        public Roles Role { get; set; }

        public ICollection<EmpTask> CreatedTasks { get; set; }
        public ICollection<TaskAssignment> AssignedTasks { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Query> Queries { get; set; }
        public ICollection<QueryResponse> Responses { get; set; }

    }
}
