using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rede_do_bem.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkToNotificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Notificacoes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Notificacoes");
        }
    }
}
