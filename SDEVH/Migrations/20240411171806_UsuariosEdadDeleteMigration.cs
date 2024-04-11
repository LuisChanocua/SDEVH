using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDEVH.Migrations
{
    /// <inheritdoc />
    public partial class UsuariosEdadDeleteMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Edad",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
