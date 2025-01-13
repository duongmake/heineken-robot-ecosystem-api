using System.Text.Json.Serialization;

namespace HeinekenRobotAPI.DTO.Create
{
    public class RobotTypeCreateDTO
    {
        [JsonIgnore]
        public Guid RobotTypeId { get; set; }
        public string RobotTypeName { get; set; }
    }
}
