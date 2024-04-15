using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDEVH.Migrations
{
    /// <inheritdoc />
    public partial class usuariosregistrohistorialtest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hora",
                table: "UsuarioHistorial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hora",
                table: "UsuarioHistorial",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
