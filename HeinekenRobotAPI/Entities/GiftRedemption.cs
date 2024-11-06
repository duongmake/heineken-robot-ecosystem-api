namespace HeinekenRobotAPI.Entities
{
    public class GiftRedemption
    {
        public Guid GiftRedemptionId { get; set; }
        public Guid CampaignId { get; set; }
        public Guid GiftId { get; set; }
        public Guid UserId { get; set; }
        public DateTime RedemptionDate { get; set; } = DateTime.Now;
        public string QrCode { get; set; }
        public string Status { get; set; }
        public DateTime? RedeemedAt { get; set; }

        public Campaign? Campaign { get; set; }
        public Gift? Gift { get; set; }
        public User? User { get; set; }
    }
}
