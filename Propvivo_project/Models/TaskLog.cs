using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Propvivo_project.Models
{
    public class TaskLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LogId { get; set; }
        [ForeignKey("TaskAssignment")]
        [Column("assignmentId")]
        public int? AssignmentId { get; set; }
        [Column("startTime")]
        public DateTime? StartTime { get; set; }
        [Column("endTime")]
        public DateTime? EndTime { get; set; }
        [Column("isBreak")]
        public bool? IsBreak { get; set; }
        [Column("durationMinutes")]
        public int? DurationMinutes {  get; set; }
        //[Column("durationMinutes")]
        //public int? DurationMinutes { get; set; }
        public TaskAssignment Assignment { get; set; }
    }
}
