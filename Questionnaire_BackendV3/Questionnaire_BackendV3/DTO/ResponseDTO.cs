using Questionnaire_BackendV3.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire_BackendV3.DTO
{
    public class ResponseDTO
    {
        public int Id { get; set; }
        public string ResponseText { get; set; }
        public int QuestionId { get; set; }

        public ResponseDTO() { }

        public ResponseDTO(Response item)
        {
            Id = item.Id;
            ResponseText = item.ResponseText;
            QuestionId = item.QuestionId;
        }
    }
}