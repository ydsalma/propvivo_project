using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Propvivo_project.Models
{
    public class TaskAssignment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AssignmentId { get; set; }
        [ForeignKey("Task")]
        [Column("taskId")]
        public int? TaskId { get; set; }
        [Column("assignedTo")]
        public int? AssignedTo { get; set; }
        [Column("Status")]
        public int? Status { get; set; }
        [Column("startTime")]
        public DateTime? StartTime { get; set; }
        [Column("endTime")]
        public DateTime? EndTime { get; set; }
        public User AssignedUser { get; set; }
        public EmpTask Task { get; set; }
        public ICollection<TaskLog> TaskLogs { get; set; }
        public ICollection<Query> Queries { get; set; }
    }
}
