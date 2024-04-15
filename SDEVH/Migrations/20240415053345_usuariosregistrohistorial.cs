using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDEVH.Migrations
{
    /// <inheritdoc />
    public partial class usuariosregistrohistorial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "UsuarioId");

            migrationBuilder.CreateTable(
                name: "UsuarioHistorial",
                columns: table => new
                {
                    IdRegistroUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRegistroUsuario = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioHistorial", x => x.IdRegistroUsuario);
                    table.ForeignKey(
                        name: "FK_UsuarioHistorial_Usuario_IdRegistroUsuario",
                        column: x => x.IdRegistroUsuario,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioHistorial_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioHistorial_UsuarioId",
                table: "UsuarioHistorial",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioHistorial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");
        }
    }
}
