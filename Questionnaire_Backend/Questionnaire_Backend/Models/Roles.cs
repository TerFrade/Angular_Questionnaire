using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire_Backend.Models
{
    [Table("Roles")]
    public class Roles
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<Users> Users { get; set; }
        public Roles()
        {
            Users = new Collection<Users>();
        }
    }
}
