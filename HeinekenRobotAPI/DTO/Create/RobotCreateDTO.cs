using System.Text.Json.Serialization;

namespace HeinekenRobotAPI.DTO.Create
{
    public class RobotCreateDTO
    {
        [JsonIgnore]
        public Guid RobotId { get; set; }
        public string RobotName { get; set; }
        public string Status { get; set; }
        public int BatteryLevel { get; set; }
        public DateTime LastAccessTime { get; set; }
        public Guid RobotTypeId { get; set; }
        public Guid LocationId { get; set; }
    }
}
