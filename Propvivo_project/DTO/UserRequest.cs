using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Propvivo_project.DTO
{
    public class UserRequest
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
       
        public string PasswordHash { get; set; }
       
        public bool IsActive { get; set; } = true;
       
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
       
        public int RoleId { get; set; }
    }
}
