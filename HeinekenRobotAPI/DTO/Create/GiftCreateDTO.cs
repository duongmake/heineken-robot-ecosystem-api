using System.Text.Json.Serialization;

namespace HeinekenRobotAPI.DTO.Create
{
    public class GiftCreateDTO
    {
        [JsonIgnore]
        public Guid GiftId { get; set; }
        public string GiftName { get; set; }
        public string Description { get; set; }
        public int TotalCount { get; set; }
        public int RedeemedCount { get; set; }
        public int ExpiredCount { get; set; }
    }
}
