using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Questionnaire_BackendV3.Database.Models
{
    [Table("Questionnaires")]
    public class Questionnaire
    {
        [Key] public int Id { get; set; }
        [Required] public string Title { get; set; }
        public string Description { get; set; }
        [Required] public bool IsPublic { get; set; }
        public string Link { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId"), Required] public virtual User User { get; set; }
    }
}