namespace HeinekenRobotAPI.Entities
{
    public class CampaignRobotMachine
    {
        public Guid CampaignRobotMachineId { get; set; }
        public Guid CampaignId { get; set; }
        public Guid RobotId { get; set; }
        public Guid RecycleMachineId { get; set; }
        public Guid LocationId { get; set; }
        public DateTime AssignedDate { get; set; } = DateTime.Now;
        public string Status { get; set; }

        public Campaign? Campaign { get; set; }
        public Robot? Robot { get; set; }
        public RecycleMachine? RecycleMachine { get; set; }
        public Location? Location { get; set; }

    }
}
