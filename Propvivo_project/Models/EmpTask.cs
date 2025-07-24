using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Propvivo_project.Models
{
    public class EmpTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TaskId { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("estimatedHours")]
        public decimal? EstimatedHours { get; set; }
        [Column("isSelfAssigned")]
        public bool? IsSelfAssigned { get; set; }
        [Column("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("createdBy")]
        public int CreatedBy { get; set; }
        public User Creator { get; set; }

        public ICollection<TaskAssignment> TaskAssignments { get; set; }
    }
}
