using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Propvivo_project.Models
{
    public class QueryResponse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ResponseId { get; set; }

        [ForeignKey("Query")]
        [Column("queryId")]
        public int? QueryId { get; set; }

        [Column("responderId")]
        public int? ResponderId { get; set; }

        [Column("responseText")]
        [MaxLength(255)]
        public string? ResponseText { get; set; }

        [Column("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Query Query { get; set; }
        public User Responder { get; set; }


    }
}
