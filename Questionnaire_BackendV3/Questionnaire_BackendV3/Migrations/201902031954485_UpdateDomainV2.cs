namespace Questionnaire_BackendV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDomainV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Picture = c.String(),
                        Index = c.Int(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        QuestionnaireId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questionnaires", t => t.QuestionnaireId, cascadeDelete: true)
                .Index(t => t.QuestionnaireId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuestionnaireId", "dbo.Questionnaires");
            DropIndex("dbo.Questions", new[] { "QuestionnaireId" });
            DropTable("dbo.Questions");
        }
    }
}
