using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediathekArr.Migrations
{
    /// <inheritdoc />
    public partial class AddRulesetApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Rulesets");

            migrationBuilder.CreateTable(
                name: "Media",
                schema: "Rulesets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    TmdbId = table.Column<int>(type: "INTEGER", nullable: true),
                    ImdbId = table.Column<string>(type: "TEXT", nullable: true),
                    TvdbId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rulesets",
                schema: "Rulesets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Topic = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    FiltersJson = table.Column<string>(type: "TEXT", nullable: false),
                    TitleRegexRulesJson = table.Column<string>(type: "TEXT", nullable: false),
                    EpisodeRegex = table.Column<string>(type: "TEXT", nullable: true),
                    SeasonRegex = table.Column<string>(type: "TEXT", nullable: true),
                    MatchingStrategy = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulesets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rulesets_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "Rulesets",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rulesets_MediaId",
                schema: "Rulesets",
                table: "Rulesets",
                column: "MediaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rulesets",
                schema: "Rulesets");

            migrationBuilder.DropTable(
                name: "Media",
                schema: "Rulesets");
        }
    }
}
