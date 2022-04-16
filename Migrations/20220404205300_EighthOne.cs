using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreAirLines_API.Migrations
{
    public partial class EighthOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passagem_PrecoBase_PromocaoPorcentagemIdPrecoBase",
                table: "Passagem");

            migrationBuilder.DropIndex(
                name: "IX_Passagem_PromocaoPorcentagemIdPrecoBase",
                table: "Passagem");

            migrationBuilder.DropColumn(
                name: "PromocaoPorcentagemIdPrecoBase",
                table: "Passagem");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Passagem",
                newName: "ValorPassagem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorPassagem",
                table: "Passagem",
                newName: "Valor");

            migrationBuilder.AddColumn<int>(
                name: "PromocaoPorcentagemIdPrecoBase",
                table: "Passagem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_PromocaoPorcentagemIdPrecoBase",
                table: "Passagem",
                column: "PromocaoPorcentagemIdPrecoBase");

            migrationBuilder.AddForeignKey(
                name: "FK_Passagem_PrecoBase_PromocaoPorcentagemIdPrecoBase",
                table: "Passagem",
                column: "PromocaoPorcentagemIdPrecoBase",
                principalTable: "PrecoBase",
                principalColumn: "IdPrecoBase",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
