using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreAirLines_API.Migrations
{
    public partial class FifthOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrecoBaseIdPrecoBase",
                table: "Passagem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Classe",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_PrecoBaseIdPrecoBase",
                table: "Passagem",
                column: "PrecoBaseIdPrecoBase");

            migrationBuilder.AddForeignKey(
                name: "FK_Passagem_PrecoBase_PrecoBaseIdPrecoBase",
                table: "Passagem",
                column: "PrecoBaseIdPrecoBase",
                principalTable: "PrecoBase",
                principalColumn: "IdPrecoBase",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passagem_PrecoBase_PrecoBaseIdPrecoBase",
                table: "Passagem");

            migrationBuilder.DropIndex(
                name: "IX_Passagem_PrecoBaseIdPrecoBase",
                table: "Passagem");

            migrationBuilder.DropColumn(
                name: "PrecoBaseIdPrecoBase",
                table: "Passagem");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Classe");
        }
    }
}
