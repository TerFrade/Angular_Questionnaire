using Questionnaire_BackendV3.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire_BackendV3.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public QuestionnaireDTO[] Questionnaires { get; set; }

        public UserDTO() { }

        public UserDTO(User item)
        {
            Id = item.Id;
            Email = item.Email;
            Username = item.Username;
            Password = item.Password;
            RoleId = item.RoleId;

            if (item.Questionnaires != null)
                Questionnaires = item.Questionnaires.Select(x => new QuestionnaireDTO(x)).ToArray();
        }
    }
}