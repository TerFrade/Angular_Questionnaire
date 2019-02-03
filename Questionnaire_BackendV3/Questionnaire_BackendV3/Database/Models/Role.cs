using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Questionnaire_BackendV3.Database.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key] public int Id { get; set; }
        [StringLength(255), Required] public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}