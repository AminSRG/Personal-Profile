using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalProfilePersistence.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Skills");

            migrationBuilder.AddColumn<byte>(
                name: "Code",
                table: "Skills",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Code");
        }
    }
}
