using System.Security.Principal;

namespace HeinekenRobotAPI.Entities
{
    public class Role
    {
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public List<User>? Users { get; set; }
    }
}
