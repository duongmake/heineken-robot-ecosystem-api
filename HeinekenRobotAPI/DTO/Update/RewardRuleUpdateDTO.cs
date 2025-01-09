namespace HeinekenRobotAPI.DTO.Update
{
    public class RewardRuleUpdateDTO
    {
        public Guid? CampaignId { get; set; }
        public Guid? GiftId { get; set; }
        public int? PointRangeMin { get; set; }
        public int? PointRangeMax { get; set; }
        public decimal? GiftChance { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
