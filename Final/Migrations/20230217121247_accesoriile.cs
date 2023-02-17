using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final.Migrations
{
    public partial class accesoriile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesoriu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accesoriul = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesoriu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccesoriuRochie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RochieID = table.Column<int>(type: "int", nullable: false),
                    AccesoriuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccesoriuRochie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccesoriuRochie_Accesoriu_AccesoriuID",
                        column: x => x.AccesoriuID,
                        principalTable: "Accesoriu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccesoriuRochie_Rochie_RochieID",
                        column: x => x.RochieID,
                        principalTable: "Rochie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccesoriuRochie_AccesoriuID",
                table: "AccesoriuRochie",
                column: "AccesoriuID");

            migrationBuilder.CreateIndex(
                name: "IX_AccesoriuRochie_RochieID",
                table: "AccesoriuRochie",
                column: "RochieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccesoriuRochie");

            migrationBuilder.DropTable(
                name: "Accesoriu");
        }
    }
}
