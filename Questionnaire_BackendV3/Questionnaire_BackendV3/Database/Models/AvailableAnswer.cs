﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Questionnaire_BackendV3.Database.Models
{
    [Table("AvailableAnswers")]
    public class AvailableAnswer
    {
        [Key]public int Id { get; set; }
        public string AnswerText { get; set; }

        public int QuestionId { get; set; }
        [ForeignKey("QuestionId"), Required] public virtual Question Question { get; set; }
    }
}