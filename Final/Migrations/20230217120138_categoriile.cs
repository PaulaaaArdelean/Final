using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final.Migrations
{
    public partial class categoriile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieID",
                table: "Rochie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rochie_CategorieID",
                table: "Rochie",
                column: "CategorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rochie_Categorie_CategorieID",
                table: "Rochie",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rochie_Categorie_CategorieID",
                table: "Rochie");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Rochie_CategorieID",
                table: "Rochie");

            migrationBuilder.DropColumn(
                name: "CategorieID",
                table: "Rochie");
        }
    }
}
