using AutoMapper;
using Propvivo_project.DTO;
using Propvivo_project.Models;

namespace Propvivo_project
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<RoleRequest, Roles>();
            CreateMap<UserRequest, User>();
            CreateMap<EmpTaskRequest, EmpTask>();
            CreateMap<QueryRequest,Query>();
            CreateMap<QueryResponseRequest, QueryResponse>();
            CreateMap<TaskAssignmentRequest, TaskAssignment>();
            CreateMap<TaskLogRequest, TaskLog>();
            CreateMap<UserRequest, User>();




        }
    }
}
