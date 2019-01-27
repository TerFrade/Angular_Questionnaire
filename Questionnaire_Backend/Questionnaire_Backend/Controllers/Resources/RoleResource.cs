using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire_Backend.Controllers.Resources
{
    public class RoleResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserResource> Users { get; set; }
        public RoleResource()
        {
            Users = new Collection<UserResource>();
        }
    }
}
