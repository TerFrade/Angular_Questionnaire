using Questionnaire_BackendV3.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire_BackendV3.DTO
{
    public class QuestionnaireDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }

        public QuestionnaireDTO() { }

        public QuestionnaireDTO(Questionnaire item)
        {
            Id = item.Id;
            Title = item.Title;
            Description = item.Description;
            IsPublic = item.IsPublic;
            Link = item.Link;
            UserId = item.UserId;
        }

    }
}