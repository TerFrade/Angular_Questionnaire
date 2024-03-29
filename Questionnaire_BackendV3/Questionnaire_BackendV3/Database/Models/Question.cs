﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire_BackendV3.Database.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Picture { get; set; }
        public int Index { get; set; }
        public bool IsRequired { get; set; }

        public int QuestionnaireId { get; set; }
        [ForeignKey("QuestionnaireId"), Required] public virtual Questionnaire Questionnaire { get; set; }

        public int QuestionTypeId { get; set; }
        [ForeignKey("QuestionTypeId"), Required] public virtual QuestionType QuestionType { get; set; }

        public virtual ICollection<AvailableAnswer> AvailableAnswers { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}