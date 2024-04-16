using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDEVH.Migrations
{
    /// <inheritdoc />
    public partial class ActulizacionUsuarioHistorial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioHistorial_Usuario_RegistradoPorUsuarioUsuarioId",
                table: "UsuarioHistorial");

            migrationBuilder.RenameColumn(
                name: "RegistradoPorUsuarioUsuarioId",
                table: "UsuarioHistorial",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioHistorial_RegistradoPorUsuarioUsuarioId",
                table: "UsuarioHistorial",
                newName: "IX_UsuarioHistorial_UsuarioId");

            migrationBuilder.AddColumn<Guid>(
                name: "RegistradoPorUsuario",
                table: "UsuarioHistorial",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioHistorial_Usuario_UsuarioId",
                table: "UsuarioHistorial",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioHistorial_Usuario_UsuarioId",
                table: "UsuarioHistorial");

            migrationBuilder.DropColumn(
                name: "RegistradoPorUsuario",
                table: "UsuarioHistorial");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "UsuarioHistorial",
                newName: "RegistradoPorUsuarioUsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioHistorial_UsuarioId",
                table: "UsuarioHistorial",
                newName: "IX_UsuarioHistorial_RegistradoPorUsuarioUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioHistorial_Usuario_RegistradoPorUsuarioUsuarioId",
                table: "UsuarioHistorial",
                column: "RegistradoPorUsuarioUsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }
    }
}
