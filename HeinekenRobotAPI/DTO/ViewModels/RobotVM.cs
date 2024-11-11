namespace HeinekenRobotAPI.DTO.ViewModels
{
    public class RobotVM
    {
        public Guid RobotId { get; set; }
        public string RobotName { get; set; }
        public string Status { get; set; }
        public int BatteryLevel { get; set; }
        public DateTime LastAccessTime { get; set; }
        public Guid RobotTypeId { get; set; }
        public string RobotTypeName { get; set; }
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
