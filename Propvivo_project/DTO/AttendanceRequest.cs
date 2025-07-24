using Propvivo_project.Models;

namespace Propvivo_project.DTO
{
    public class AttendanceRequest
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime WorkDate { get; set; }
        public int TotalWorkMinutes { get; set; }
        public int TotalBreakMinutes { get; set; }
        public bool Completed8Hours { get; set; }
    }
}
