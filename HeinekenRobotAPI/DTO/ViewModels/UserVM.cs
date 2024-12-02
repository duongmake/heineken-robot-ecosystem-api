namespace HeinekenRobotAPI.DTO.ViewModels
{
    public class UserVM
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }

    }
}
