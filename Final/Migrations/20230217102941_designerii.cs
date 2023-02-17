using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final.Migrations
{
    public partial class designerii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignerID",
                table: "Rochie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Designer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeDesigner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rochie_DesignerID",
                table: "Rochie",
                column: "DesignerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rochie_Designer_DesignerID",
                table: "Rochie",
                column: "DesignerID",
                principalTable: "Designer",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rochie_Designer_DesignerID",
                table: "Rochie");

            migrationBuilder.DropTable(
                name: "Designer");

            migrationBuilder.DropIndex(
                name: "IX_Rochie_DesignerID",
                table: "Rochie");

            migrationBuilder.DropColumn(
                name: "DesignerID",
                table: "Rochie");
        }
    }
}
