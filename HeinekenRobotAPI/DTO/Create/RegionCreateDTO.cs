using System.Text.Json.Serialization;

namespace HeinekenRobotAPI.DTO.Create
{
    public class RegionCreateDTO
    {
        [JsonIgnore]
        public Guid RegionId { get; set; }
        public string RegionName { get; set; }
        public string Province { get; set; }
    }
}
