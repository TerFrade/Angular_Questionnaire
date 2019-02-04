using Questionnaire_BackendV3.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire_BackendV3.DTO
{
    public class AvailableAnswerDTO
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }

        public AvailableAnswerDTO() { }

        public AvailableAnswerDTO(AvailableAnswer item)
        {
            Id = item.Id;
            AnswerText = item.AnswerText;
            QuestionId = item.QuestionId;
        }
    }
}