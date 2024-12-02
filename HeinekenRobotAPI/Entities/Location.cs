namespace HeinekenRobotAPI.Entities
{
    public class Location
    {
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public Guid RegionId { get; set; }
        public Region? Region { get; set; }
        public List<CampaignRobotMachine>? CampaignRobotMachines { get; set; }
        public List<RecycleMachine>? RecycleMachines { get; set; }
        public List<Robot>? Robots { get; set; }



    }
}
