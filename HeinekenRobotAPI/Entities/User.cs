namespace HeinekenRobotAPI.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Guid RoleID { get; set; }
        public Role? Role { get; set; }

    }
}
