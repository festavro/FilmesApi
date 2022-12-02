﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlimesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnClassificacaoEtariaFilmes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassificacaoEtaria",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassificacaoEtaria",
                table: "Filmes");
        }
    }
}