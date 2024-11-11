namespace HeinekenRobotAPI.Entities
{
    public class RobotType
    {
        public Guid RobotTypeId { get; set; }
        public string RobotTypeName { get; set; }

        public List<Robot>? Robots { get; set; }
    }
}
