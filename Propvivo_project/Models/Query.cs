using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Propvivo_project.Models
{
    public class Query
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QueryId { get; set; }

        [ForeignKey("TaskAssignment")]
        [Column("assignmentId")]
        public int? AssignmentId { get; set; }
        [ForeignKey("User")]
        [Column("userId")]
        public int? UserId { get; set; }

        [Column("subject")]
        [MaxLength(100)]
        public string? Subject { get; set; }

        [Column("description")]
        [MaxLength(100)]
        public string? Description { get; set; }

        [Column("filePath")]
        [MaxLength(255)]
        public string? FilePath { get; set; }
        [Column("status")]
        public int? Status { get; set; } 
        [Column("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public TaskAssignment Assignment { get; set; }
        public User User { get; set; }
        public ICollection<QueryResponse> Responses { get; set; }
    }
}
