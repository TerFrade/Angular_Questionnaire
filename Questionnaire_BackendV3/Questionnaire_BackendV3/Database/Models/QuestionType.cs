using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire_BackendV3.Database.Models
{
    [Table("QuestionTypes")]
    public class QuestionType
    {
        [Key]public int Id { get; set; }
        [StringLength(255),Required]public string TypeName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}