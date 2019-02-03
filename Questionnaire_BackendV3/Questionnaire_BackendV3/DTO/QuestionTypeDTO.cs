using Questionnaire_BackendV3.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire_BackendV3.DTO
{
    public class QuestionTypeDTO
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public QuestionDTO[] Questions { get; set; }

        public QuestionTypeDTO() { }

        public QuestionTypeDTO(QuestionType item)
        {
            Id = item.Id;
            TypeName = item.TypeName;

            if (item.Questions != null)
                Questions = item.Questions.Select(x => new QuestionDTO(x)).ToArray();
        }
    }
}