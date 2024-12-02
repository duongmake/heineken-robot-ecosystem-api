using System.Text.Json.Serialization;

namespace HeinekenRobotAPI.DTO.Create
{
    public class UserCreateDTO
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Guid RoleID { get; set; }
    }
}
