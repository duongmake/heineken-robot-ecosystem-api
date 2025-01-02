namespace HeinekenRobotAPI.DTO.Update
{
    public class RecycleMachineUpdateDTO
    {
        public string? MachineCode { get; set; }
        public string? Status { get; set; }
        public string? ContainerStatus { get; set; }
        public DateTime? LastServiceDate { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? Interaction { get; set; }

        public Guid? LocationId { get; set; }
    }
}
