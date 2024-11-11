namespace HeinekenRobotAPI.Entities
{
    public class Region
    {
        public Guid RegionId { get; set; }
        public string RegionName { get; set; }
        public string Province { get; set; }

        public List<Location>? Locations { get; set; }
    }
}
