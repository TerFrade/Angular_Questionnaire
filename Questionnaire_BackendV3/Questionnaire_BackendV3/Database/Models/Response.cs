using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Questionnaire_BackendV3.Database.Models
{
    [Table("Responses")]
    public class Response
    {
        [Key]public int Id { get; set; }
        public string ResponseText { get; set; }

        public int QuestionId { get; set; }
        [ForeignKey("QuestionId"), Required] public virtual Question Question { get; set; }
    }
}