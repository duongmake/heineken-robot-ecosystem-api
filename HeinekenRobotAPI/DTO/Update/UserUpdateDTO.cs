﻿namespace HeinekenRobotAPI.DTO.Update
{
    public class UserUpdateDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public Guid? RoleID { get; set; }
    }
}
