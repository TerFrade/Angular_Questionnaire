namespace Questionnaire_BackendV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDomainV31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "QuestionText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "QuestionText");
        }
    }
}
