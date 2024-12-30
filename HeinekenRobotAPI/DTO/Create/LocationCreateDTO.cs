using System.Text.Json.Serialization;

namespace HeinekenRobotAPI.DTO.Create
{
    public class LocationCreateDTO
    {
        [JsonIgnore]
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Guid RegionId { get; set; }
    }
}
