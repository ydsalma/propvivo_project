using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Propvivo_project.Models
{
    public class Attendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AttendanceId { get; set; }

        [ForeignKey("User")]
        [Column("userId")]
        public int? UserId { get; set; }

        [Column("workDate")]
        public DateTime? WorkDate { get; set; }

        [Column("totalWorkMinutes")]
        public int? TotalWorkMinutes { get; set; }

        [Column("totalBreakMinutes")]
        public int? TotalBreakMinutes { get; set; }

        [Column("completed8Hours")]
        public bool? Completed8Hours { get; set; }

        public User User { get; set; }

    }
}
