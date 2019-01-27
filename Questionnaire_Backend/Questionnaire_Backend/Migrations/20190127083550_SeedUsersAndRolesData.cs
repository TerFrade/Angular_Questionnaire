using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionnaire_Backend.Migrations
{
    public partial class SeedUsersAndRolesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Roles (Name) Values ('Admin')");
            migrationBuilder.Sql("INSERT INTO Roles (Name) Values ('Member')");

            migrationBuilder.Sql("INSERT INTO Users (Username, Email, Password, RolesId) Values ('zENJA','zenja@gmail.com','admin123',(SELECT ID From Roles WHERE Name ='Admin'))");
            migrationBuilder.Sql("INSERT INTO Users (Username, Email, Password, RolesId) Values ('Terence','Terence@gmail.com','ter123',(SELECT ID From Roles WHERE Name ='Member'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Roles WHERE Name IN ('Admin', 'Member')");
        }
    }
}
