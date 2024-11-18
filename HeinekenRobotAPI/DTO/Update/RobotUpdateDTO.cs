namespace HeinekenRobotAPI.DTO.Update
{
    public class RobotUpdateDTO
    {
        public string? RobotName { get; set; }
        public string? Status { get; set; }
        public int? BatteryLevel { get; set; }
        public DateTime? LastAccessTime { get; set; }
        public Guid? RobotTypeId { get; set; }
        public Guid? LocationId { get; set; }
    }
}
