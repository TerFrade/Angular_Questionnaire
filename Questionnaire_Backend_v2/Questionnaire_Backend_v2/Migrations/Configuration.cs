namespace Questionnaire_Backend_v2.Migrations
{
    using Questionnaire_Backend_v2.Database.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Questionnaire_Backend_v2.Models.QuestionnaireDBv2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Questionnaire_Backend_v2.Models.QuestionnaireDBv2Context context)
        {

        }
    }
}
