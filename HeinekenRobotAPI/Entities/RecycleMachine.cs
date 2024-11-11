﻿namespace HeinekenRobotAPI.Entities
{
    public class RecycleMachine
    {
        public Guid RecycleMachineId { get; set; }
        public string MachineCode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ContainerStatus { get; set; } = string.Empty;
        public DateTime LastServiceDate { get; set; }

        public Guid LocationId { get; set; }
        public Location? Location { get; set; }
        public List<CampaignRobotMachine>? CampaignRobotMachines { get; set; }
    }
}
