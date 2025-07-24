using Microsoft.EntityFrameworkCore;
using Propvivo_project.Models;

namespace Propvivo_project.Context
{
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<EmpTask> Tasks { get; set; }
        public virtual DbSet<TaskAssignment> TaskAssignments { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Query> Queries { get; set; }
        public virtual DbSet<QueryResponse> QueryResponses { get; set; }
        public virtual DbSet<TaskLog> TaskLogs { get; set; }

    }
}
