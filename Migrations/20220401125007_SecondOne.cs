using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreAirLines_API.Migrations
{
    public partial class SecondOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Voo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdAeronave",
                table: "Voo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Passageiro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Aeroporto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Voo");

            migrationBuilder.DropColumn(
                name: "IdAeronave",
                table: "Voo");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Passageiro");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Aeroporto");
        }
    }
}
