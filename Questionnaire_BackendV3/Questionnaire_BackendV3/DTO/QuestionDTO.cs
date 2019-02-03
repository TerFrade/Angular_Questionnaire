using Questionnaire_BackendV3.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire_BackendV3.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public int Index { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionnaireId { get; set; }
        public int QuestionTypeId { get; set; }

        public QuestionDTO() { }

        public QuestionDTO(Question item)
        {
            Id = item.Id;
            Picture = item.Picture;
            Index = item.Index;
            IsRequired = item.IsRequired;
            QuestionnaireId = item.QuestionnaireId;
            QuestionTypeId = item.QuestionTypeId;
        }
    }
}