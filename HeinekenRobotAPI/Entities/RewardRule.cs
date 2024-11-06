namespace HeinekenRobotAPI.Entities
{
    public class RewardRule
    {
        public Guid RewardRuleId { get; set; }
        public Guid CampaignId { get; set; }
        public int PointRangeMin { get; set; }
        public int PointRangeMax { get; set; }
        public Guid GiftId { get; set; }
        public decimal GiftChance { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Campaign? Campaign { get; set; }
        public Gift? Gift { get; set; }
    }
}
