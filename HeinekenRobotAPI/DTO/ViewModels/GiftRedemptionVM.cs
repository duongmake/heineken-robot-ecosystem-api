namespace HeinekenRobotAPI.DTO.ViewModels
{
    public class GiftRedemptionVM
    {
        public Guid GiftRedemptionId { get; set; }
        public Guid CampaignId { get; set; }
        public string CampaignName { get; set; }
        public Guid GiftId { get; set; }
        public string GiftName { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid RecycleMachineId { get; set; }
        public string MachineCode { get; set; }
        public DateTime RedemptionDate { get; set; } = DateTime.Now;
        public string QrCode { get; set; }
        public string Status { get; set; }
        public DateTime? RedeemedAt { get; set; }
    }
}
