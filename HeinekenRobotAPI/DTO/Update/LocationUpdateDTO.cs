namespace HeinekenRobotAPI.DTO.Update
{
    public class LocationUpdateDTO
    {
        public string? LocationName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public Guid? RegionId { get; set; }
    }
}
