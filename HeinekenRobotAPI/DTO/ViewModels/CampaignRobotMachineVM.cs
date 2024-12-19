namespace HeinekenRobotAPI.DTO.ViewModels
{
    public class CampaignRobotMachineVM
    {
        public Guid CampaignRobotMachineId { get; set; }
        public Guid CampaignId { get; set; }
        public string CampaignName { get; set; }
        public Guid RobotId { get; set; }
        public string RobotName { get; set; }
        public Guid RecycleMachineId { get; set; }
        public string MachineCode { get; set; }
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public DateTime AssignedDate { get; set; } = DateTime.Now;
        public string Status { get; set; }
    }
}
