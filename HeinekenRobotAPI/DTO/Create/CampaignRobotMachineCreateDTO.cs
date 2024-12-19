using System.Text.Json.Serialization;

namespace HeinekenRobotAPI.DTO.Create
{
    public class CampaignRobotMachineCreateDTO
    {
        [JsonIgnore]
        public Guid CampaignRobotMachineId { get; set; }
        public Guid CampaignId { get; set; }
        public Guid RobotId { get; set; }
        public Guid RecycleMachineId { get; set; }
        public Guid LocationId { get; set; }
        public DateTime AssignedDate { get; set; } = DateTime.Now;
        public string Status { get; set; }
    }
}
