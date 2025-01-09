using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DTO.ViewModels
{
    public class RewardRuleVM
    {
        public Guid RewardRuleId { get; set; }
        public int PointRangeMin { get; set; }
        public int PointRangeMax { get; set; }
        public decimal GiftChance { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid CampaignId { get; set; }
        public string CampaignName { get; set; }
        public Guid GiftId { get; set; }
        public string GiftName { get; set; }
    }
}
