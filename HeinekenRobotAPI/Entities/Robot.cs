namespace HeinekenRobotAPI.Entities
{
    public class Robot
    {
        public Guid RobotId { get; set; }
        public string RobotName { get; set; }
        public string Status { get; set; }
        public int BatteryLevel { get; set; }
        public DateTime LastAccessTime { get; set; }

        public Guid RobotTypeId { get; set; }
        public RobotType? RobotType { get; set; }
        public Guid LocationId { get; set; }
        public Location? Location { get; set; }
        public List<CampaignRobotMachine>? CampaignRobotMachines { get; set; }
    }
}
