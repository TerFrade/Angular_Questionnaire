using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Questionnaire_Backend.Models;

namespace Questionnaire_Backend.Models
{
    public class QuestionnaireDbContext : DbContext
    {
        public QuestionnaireDbContext (DbContextOptions<QuestionnaireDbContext> options)
            : base(options)
        {
        }

        public DbSet<Questionnaire_Backend.Models.Roles> Roles { get; set; }

        public DbSet<Questionnaire_Backend.Models.Users> Users { get; set; }
    }
}
