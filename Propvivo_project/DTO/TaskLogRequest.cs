using Propvivo_project.Models;

namespace Propvivo_project.DTO
{
    public class TaskLogRequest
    {
        public int AssignmentId { get; set; }
        public TaskAssignment Assignment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBreak { get; set; }

        public int DurationMinutes => (int)(EndTime - StartTime).TotalMinutes;
    }
}
