using Propvivo_project.Models;

namespace Propvivo_project.DTO
{
    public class QueryResponseRequest
    {
        public int QueryId { get; set; }
        public Query Query { get; set; }
        public int ResponderId { get; set; }
        public User Responder { get; set; }
        public string ResponseText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
