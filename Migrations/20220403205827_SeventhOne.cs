using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreAirLines_API.Migrations
{
    public partial class SeventhOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passagem_PrecoBase_ValorIdPrecoBase",
                table: "Passagem");

            migrationBuilder.DropForeignKey(
                name: "FK_PrecoBase_Classe_ClasseIdClasse",
                table: "PrecoBase");

            migrationBuilder.DropIndex(
                name: "IX_PrecoBase_ClasseIdClasse",
                table: "PrecoBase");

            migrationBuilder.DropColumn(
                name: "ClasseIdClasse",
                table: "PrecoBase");

            migrationBuilder.RenameColumn(
                name: "ValorIdPrecoBase",
                table: "Passagem",
                newName: "PromocaoPorcentagemIdPrecoBase");

            migrationBuilder.RenameIndex(
                name: "IX_Passagem_ValorIdPrecoBase",
                table: "Passagem",
                newName: "IX_Passagem_PromocaoPorcentagemIdPrecoBase");

            migrationBuilder.RenameColumn(
                name: "IdAeronave",
                table: "Aeroporto",
                newName: "Nome");

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "PrecoBase",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Passagem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Passagem_PrecoBase_PromocaoPorcentagemIdPrecoBase",
                table: "Passagem",
                column: "PromocaoPorcentagemIdPrecoBase",
                principalTable: "PrecoBase",
                principalColumn: "IdPrecoBase",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passagem_PrecoBase_PromocaoPorcentagemIdPrecoBase",
                table: "Passagem");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Passagem");

            migrationBuilder.RenameColumn(
                name: "PromocaoPorcentagemIdPrecoBase",
                table: "Passagem",
                newName: "ValorIdPrecoBase");

            migrationBuilder.RenameIndex(
                name: "IX_Passagem_PromocaoPorcentagemIdPrecoBase",
                table: "Passagem",
                newName: "IX_Passagem_ValorIdPrecoBase");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Aeroporto",
                newName: "IdAeronave");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "PrecoBase",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "ClasseIdClasse",
                table: "PrecoBase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrecoBase_ClasseIdClasse",
                table: "PrecoBase",
                column: "ClasseIdClasse");

            migrationBuilder.AddForeignKey(
                name: "FK_Passagem_PrecoBase_ValorIdPrecoBase",
                table: "Passagem",
                column: "ValorIdPrecoBase",
                principalTable: "PrecoBase",
                principalColumn: "IdPrecoBase",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrecoBase_Classe_ClasseIdClasse",
                table: "PrecoBase",
                column: "ClasseIdClasse",
                principalTable: "Classe",
                principalColumn: "IdClasse",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
