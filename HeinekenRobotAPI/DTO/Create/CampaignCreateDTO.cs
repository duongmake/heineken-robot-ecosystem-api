﻿using System.Text.Json.Serialization;

namespace HeinekenRobotAPI.DTO.Create
{
    public class CampaignCreateDTO
    {
        [JsonIgnore]
        public Guid CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public Guid RegionId { get; set; }
    }
}
