using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final.Migrations
{
    public partial class marimile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarimeID",
                table: "Rochie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Marime",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marimea = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marime", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rochie_MarimeID",
                table: "Rochie",
                column: "MarimeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rochie_Marime_MarimeID",
                table: "Rochie",
                column: "MarimeID",
                principalTable: "Marime",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rochie_Marime_MarimeID",
                table: "Rochie");

            migrationBuilder.DropTable(
                name: "Marime");

            migrationBuilder.DropIndex(
                name: "IX_Rochie_MarimeID",
                table: "Rochie");

            migrationBuilder.DropColumn(
                name: "MarimeID",
                table: "Rochie");
        }
    }
}
