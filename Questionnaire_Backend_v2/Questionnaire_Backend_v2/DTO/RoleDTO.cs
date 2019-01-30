using Questionnaire_Backend_v2.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire_Backend_v2.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserDTO[] Users { get; set; }
        public RoleDTO(Role item)
        {
            Id = item.Id;
            Name = item.Name;
            if (item.Users != null)
            {
                Users = item.Users.Select(x => new UserDTO(x)).ToArray();
            }
        }
    }
}