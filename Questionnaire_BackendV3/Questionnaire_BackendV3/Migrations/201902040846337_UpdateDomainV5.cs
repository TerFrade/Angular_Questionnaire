namespace Questionnaire_BackendV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDomainV5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResponseText = c.String(),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responses", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Responses", new[] { "QuestionId" });
            DropTable("dbo.Responses");
        }
    }
}
