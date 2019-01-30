using Questionnaire_Backend_v2.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire_Backend_v2.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public UserDTO() { }
        public UserDTO(User item)
        {
            Id = item.Id;
            Username = item.Username;
            Email = item.Email;
            Password = item.Password;
            RoleId = item.Role.Id;
        }
        
    }
}