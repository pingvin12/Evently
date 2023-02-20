using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientBackendNoAuth.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "events");

            migrationBuilder.CreateTable(
                name: "events",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    location = table.Column<string>(type: "character varying", nullable: true),
                    country = table.Column<string>(type: "character varying", nullable: true),
                    capacity = table.Column<decimal[]>(type: "numeric[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("events_pk", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "events_id_idx",
                schema: "events",
                table: "events",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "events",
                schema: "events");
        }
    }
}
