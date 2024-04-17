﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDEVH.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracionyucli2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "Usuario",
                type: "int",
                nullable: true);
        }
    }
}
