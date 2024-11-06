namespace HeinekenRobotAPI.Entities
{
    public class Location
    {
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public string Province { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Guid RegionId { get; set; }
        public Region? Region { get; set; }
        public List<CampaignRobotMachine>? CampaignRobotMachines { get; set; }



    }
}
