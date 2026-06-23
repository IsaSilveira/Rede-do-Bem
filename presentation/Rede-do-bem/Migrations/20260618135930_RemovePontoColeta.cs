using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rede_do_bem.Migrations
{
    /// <inheritdoc />
    public partial class RemovePontoColeta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanhas_PontoColeta_PontoColetaId",
                table: "Campanhas");

            migrationBuilder.DropTable(
                name: "PontoColeta");

            migrationBuilder.DropIndex(
                name: "IX_Campanhas_PontoColetaId",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "PontoColetaId",
                table: "Campanhas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PontoColetaId",
                table: "Campanhas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PontoColeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ativa = table.Column<bool>(type: "INTEGER", nullable: false),
                    Avaliacao = table.Column<double>(type: "REAL", nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CEP = table.Column<string>(type: "TEXT", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    Favoritado = table.Column<bool>(type: "INTEGER", nullable: false),
                    FotoPerfil = table.Column<string>(type: "TEXT", nullable: true),
                    Fotos = table.Column<string>(type: "TEXT", nullable: false),
                    Horario = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Site = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    TiposDoacao = table.Column<string>(type: "TEXT", nullable: false),
                    TotalAvaliacoes = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoColeta", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_PontoColetaId",
                table: "Campanhas",
                column: "PontoColetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campanhas_PontoColeta_PontoColetaId",
                table: "Campanhas",
                column: "PontoColetaId",
                principalTable: "PontoColeta",
                principalColumn: "Id");
        }
    }
}
