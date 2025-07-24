using Propvivo_project.Models;

namespace Propvivo_project.DTO
{
    public class TaskAssignmentRequest
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int AssignedTo { get; set; }
        public User AssignedUser { get; set; }

        public int Status { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
