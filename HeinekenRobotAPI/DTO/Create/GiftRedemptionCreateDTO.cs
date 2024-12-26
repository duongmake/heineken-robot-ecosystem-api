using System.Text.Json.Serialization;

namespace HeinekenRobotAPI.DTO.Create
{
    public class GiftRedemptionCreateDTO
    {
        [JsonIgnore]
        public Guid GiftRedemptionId { get; set; }
        public Guid CampaignId { get; set; }
        public Guid GiftId { get; set; }
        public Guid UserId { get; set; }
        public Guid RecycleMachineId { get; set; }
        public DateTime RedemptionDate { get; set; }
        public string QrCode { get; set; }
        public string Status { get; set; }
        public DateTime? RedeemedAt { get; set; }
    }
}
