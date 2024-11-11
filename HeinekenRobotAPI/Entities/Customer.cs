namespace HeinekenRobotAPI.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int PointsBalance { get; set; }

        public List<Transaction>? Transactions { get; set; }
    }
}
