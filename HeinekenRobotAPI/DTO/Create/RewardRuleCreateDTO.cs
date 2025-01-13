﻿using System.Text.Json.Serialization;

namespace HeinekenRobotAPI.DTO.Create
{
    public class RewardRuleCreateDTO
    {
        [JsonIgnore]
        public Guid RewardRuleId { get; set; }
        public Guid CampaignId { get; set; }
        public Guid GiftId { get; set; }
        public int PointRangeMin { get; set; }
        public int PointRangeMax { get; set; }
        public decimal GiftChance { get; set; }
        public DateTime CreateTime { get; set; }
    }
}