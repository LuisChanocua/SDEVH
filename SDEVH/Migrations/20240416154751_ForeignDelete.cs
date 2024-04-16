using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDEVH.Migrations
{
    /// <inheritdoc />
    public partial class ForeignDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioHistorial_Usuario_UsuarioId",
                table: "UsuarioHistorial");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioHistorial_UsuarioId",
                table: "UsuarioHistorial");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "UsuarioHistorial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "UsuarioHistorial",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioHistorial_UsuarioId",
                table: "UsuarioHistorial",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioHistorial_Usuario_UsuarioId",
                table: "UsuarioHistorial",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }
    }
}
