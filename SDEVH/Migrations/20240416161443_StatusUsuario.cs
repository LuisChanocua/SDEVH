using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDEVH.Migrations
{
    /// <inheritdoc />
    public partial class StatusUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Usuario",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Usuario");
        }
    }
}
