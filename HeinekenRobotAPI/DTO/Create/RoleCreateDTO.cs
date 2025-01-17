using System.Text.Json.Serialization;

namespace HeinekenRobotAPI.DTO.Create
{
    public class RoleCreateDTO
    {
        [JsonIgnore]
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
