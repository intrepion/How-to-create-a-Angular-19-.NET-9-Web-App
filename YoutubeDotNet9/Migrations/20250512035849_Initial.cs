using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeDotNet9.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    PokedexNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    RegionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.PokemonId);
                    table.ForeignKey(
                        name: "FK_Pokemon_Region",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId");
                    table.ForeignKey(
                        name: "FK_Pokemon_Type",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "TypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_RegionId",
                table: "Pokemon",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_TypeId",
                table: "Pokemon",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
