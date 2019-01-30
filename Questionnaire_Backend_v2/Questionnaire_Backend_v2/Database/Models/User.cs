using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Questionnaire_Backend_v2.Database.Models
{
    [Table("Users")]
    public class User
    {
        [Key]public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId"), Required] public Role Role { get; set; }
    }
}