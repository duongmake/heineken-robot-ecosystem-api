namespace RobotAPI.Entities
{
    public class Robot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime LastAccessTime { get; set; }
        public int BatteryLevel { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
