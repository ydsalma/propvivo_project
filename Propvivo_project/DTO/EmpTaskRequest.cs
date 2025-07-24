namespace Propvivo_project.DTO
{
    public class EmpTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? EstimatedHours { get; set; }
        public bool IsSelfAssigned { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int CreatedBy { get; set; }
    }
}
