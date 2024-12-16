namespace HeinekenRobotAPI.DTO.Update
{
    public class CampaignRobotMachineUpdateDTO
    {
        public Guid? CampaignId { get; set; }
        public Guid? RobotId { get; set; }
        public Guid? RecycleMachineId { get; set; }
        public Guid? LocationId { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string? Status { get; set; }
    }
}
