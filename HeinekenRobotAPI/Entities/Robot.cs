namespace HeinekenRobotAPI.Entities
{
    public class Robot
    {
        public Guid RobotId { get; set; }
        public string RobotCode { get; set; }
        public string RobotType { get; set; }
        public string Status { get; set; }
        public int BatteryLevel { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Guid LocationId { get; set; }
        public Location? Location { get; set; }
        public List<CampaignRobotMachine> CampaignRobotMachines { get; set; }
    }
}
