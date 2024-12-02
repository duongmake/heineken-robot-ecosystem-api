namespace HeinekenRobotAPI.Entities
{
    public class Campaign
    {
        public Guid CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        public Guid RegionId { get; set; }
        public Region? Region { get; set; }
        public List<CampaignRobotMachine>? CampaignRobotMachines { get; set; }
        public List<RewardRule>? RewardRules { get; set; }

    }
}
