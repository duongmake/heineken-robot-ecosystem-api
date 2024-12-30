using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DTO.ViewModels
{
    public class LocationVM
    {
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public Guid RegionId { get; set; }
        public string RegionName { get; set; }
    }
}
