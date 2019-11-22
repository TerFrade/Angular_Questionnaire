namespace Questionnaire_BackendV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDomainV4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvailableAnswers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.AvailableAnswers", new[] { "QuestionId" });
            DropTable("dbo.AvailableAnswers");
        }
    }
}
