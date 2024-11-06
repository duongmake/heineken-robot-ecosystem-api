namespace HeinekenRobotAPI.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid CampaignId { get; set; }
        public Guid RobotId { get; set; }
        public Guid RecycleMachineId { get; set; }
        public Guid LocationId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GiftId { get; set; }
        public int PointsEarned { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public Campaign? Campaign { get; set; }
        public Robot? Robot { get; set; }
        public RecycleMachine? RecycleMachine { get; set; }
        public Location? Location { get; set; }
        public Customer? Customer { get; set; }
        public Gift? Gift { get; set; }
    }
}
