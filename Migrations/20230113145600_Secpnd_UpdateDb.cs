using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentApi.Migrations
{
    public partial class Secpnd_UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "User_Info",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Info_DepartmentId",
                table: "User_Info",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Info_Department_DepartmentId",
                table: "User_Info",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Info_Department_DepartmentId",
                table: "User_Info");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_User_Info_DepartmentId",
                table: "User_Info");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "User_Info");
        }
    }
}
