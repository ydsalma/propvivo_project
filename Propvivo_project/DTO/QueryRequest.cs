using Propvivo_project.Models;

namespace Propvivo_project.DTO
{
    public class QueryRequest
    {
        public int AssignmentId { get; set; }
        public TaskAssignment Assignment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
