using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication05.Migrations
{
    public partial class AddedIsWorkerProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWorker",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWorker",
                table: "AspNetUsers");
        }
    }
}
