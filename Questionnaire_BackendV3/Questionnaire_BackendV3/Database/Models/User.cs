using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire_BackendV3.Database.Models
{
    [Table("Users")]
    public class User
    {
        [Key] public int Id { get; set; }
        [Required] public string Email { get; set; }
        [StringLength(255),Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId"), Required] public virtual Role Role { get; set; }
        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
    }
}