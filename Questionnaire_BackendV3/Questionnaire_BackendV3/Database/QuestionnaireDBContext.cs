using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Questionnaire_BackendV3.Models
{
    public class QuestionnaireDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public QuestionnaireDBContext() : base("name=QuestionnaireDBContext")
        {
        }

        public System.Data.Entity.DbSet<Questionnaire_BackendV3.Database.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<Questionnaire_BackendV3.Database.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Questionnaire_BackendV3.Database.Models.Questionnaire> Questionnaires { get; set; }

        public System.Data.Entity.DbSet<Questionnaire_BackendV3.Database.Models.QuestionType> QuestionTypes { get; set; }

        public System.Data.Entity.DbSet<Questionnaire_BackendV3.Database.Models.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<Questionnaire_BackendV3.Database.Models.AvailableAnswer> AvailableAnswers { get; set; }

        public System.Data.Entity.DbSet<Questionnaire_BackendV3.Database.Models.Response> Responses { get; set; }
    }
}
