using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cooldown = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityID);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    WeaponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.WeaponID);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: false),
                    Shield = table.Column<int>(type: "int", nullable: false),
                    PrimaryFireID = table.Column<int>(type: "int", nullable: true),
                    SecondaryFireID = table.Column<int>(type: "int", nullable: true),
                    Ability1ID = table.Column<int>(type: "int", nullable: true),
                    Ability2ID = table.Column<int>(type: "int", nullable: true),
                    UltimateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Heroes_Abilities_Ability1ID",
                        column: x => x.Ability1ID,
                        principalTable: "Abilities",
                        principalColumn: "AbilityID");
                    table.ForeignKey(
                        name: "FK_Heroes_Abilities_Ability2ID",
                        column: x => x.Ability2ID,
                        principalTable: "Abilities",
                        principalColumn: "AbilityID");
                    table.ForeignKey(
                        name: "FK_Heroes_Abilities_UltimateID",
                        column: x => x.UltimateID,
                        principalTable: "Abilities",
                        principalColumn: "AbilityID");
                    table.ForeignKey(
                        name: "FK_Heroes_Weapons_PrimaryFireID",
                        column: x => x.PrimaryFireID,
                        principalTable: "Weapons",
                        principalColumn: "WeaponID");
                    table.ForeignKey(
                        name: "FK_Heroes_Weapons_SecondaryFireID",
                        column: x => x.SecondaryFireID,
                        principalTable: "Weapons",
                        principalColumn: "WeaponID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_Ability1ID",
                table: "Heroes",
                column: "Ability1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_Ability2ID",
                table: "Heroes",
                column: "Ability2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_PrimaryFireID",
                table: "Heroes",
                column: "PrimaryFireID");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_SecondaryFireID",
                table: "Heroes",
                column: "SecondaryFireID");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_UltimateID",
                table: "Heroes",
                column: "UltimateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
