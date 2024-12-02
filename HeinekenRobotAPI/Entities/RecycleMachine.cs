namespace HeinekenRobotAPI.Entities
{
    public class RecycleMachine
    {
        public Guid RecycleMachineId { get; set; }
        public string MachineCode { get; set; }
        public string Status { get; set; }
        public string ContainerStatus { get; set; }
        public DateTime LastServiceDate { get; set; }
        public DateTime CreateTime { get; set; }
        public int Interaction { get; set; }

        public Guid LocationId { get; set; }
        public Location? Location { get; set; }
        public List<CampaignRobotMachine>? CampaignRobotMachines { get; set; }
        public List<GiftRedemption>? GiftRedemptions { get; set; }
    }
}
