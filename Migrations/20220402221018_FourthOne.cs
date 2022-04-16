using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreAirLines_API.Migrations
{
    public partial class FourthOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voo_Passageiro_PassageiroCpf",
                table: "Voo");

            migrationBuilder.DropIndex(
                name: "IX_Voo_PassageiroCpf",
                table: "Voo");

            migrationBuilder.DropColumn(
                name: "PassageiroCpf",
                table: "Voo");

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    IdClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.IdClasse);
                });

            migrationBuilder.CreateTable(
                name: "PrecoBase",
                columns: table => new
                {
                    IdPrecoBase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PromocaoPorcentagem = table.Column<double>(type: "float", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestinoSigla = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrigemSigla = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClasseIdClasse = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecoBase", x => x.IdPrecoBase);
                    table.ForeignKey(
                        name: "FK_PrecoBase_Aeroporto_DestinoSigla",
                        column: x => x.DestinoSigla,
                        principalTable: "Aeroporto",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrecoBase_Aeroporto_OrigemSigla",
                        column: x => x.OrigemSigla,
                        principalTable: "Aeroporto",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrecoBase_Classe_ClasseIdClasse",
                        column: x => x.ClasseIdClasse,
                        principalTable: "Classe",
                        principalColumn: "IdClasse",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passagem",
                columns: table => new
                {
                    IdPassagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VooIdVoo = table.Column<int>(type: "int", nullable: true),
                    PassageiroCpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ValorIdPrecoBase = table.Column<int>(type: "int", nullable: true),
                    ClasseIdClasse = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagem", x => x.IdPassagem);
                    table.ForeignKey(
                        name: "FK_Passagem_Classe_ClasseIdClasse",
                        column: x => x.ClasseIdClasse,
                        principalTable: "Classe",
                        principalColumn: "IdClasse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passagem_Passageiro_PassageiroCpf",
                        column: x => x.PassageiroCpf,
                        principalTable: "Passageiro",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passagem_PrecoBase_ValorIdPrecoBase",
                        column: x => x.ValorIdPrecoBase,
                        principalTable: "PrecoBase",
                        principalColumn: "IdPrecoBase",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passagem_Voo_VooIdVoo",
                        column: x => x.VooIdVoo,
                        principalTable: "Voo",
                        principalColumn: "IdVoo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_ClasseIdClasse",
                table: "Passagem",
                column: "ClasseIdClasse");

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_PassageiroCpf",
                table: "Passagem",
                column: "PassageiroCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_ValorIdPrecoBase",
                table: "Passagem",
                column: "ValorIdPrecoBase");

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_VooIdVoo",
                table: "Passagem",
                column: "VooIdVoo");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoBase_ClasseIdClasse",
                table: "PrecoBase",
                column: "ClasseIdClasse");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoBase_DestinoSigla",
                table: "PrecoBase",
                column: "DestinoSigla");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoBase_OrigemSigla",
                table: "PrecoBase",
                column: "OrigemSigla");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passagem");

            migrationBuilder.DropTable(
                name: "PrecoBase");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.AddColumn<string>(
                name: "PassageiroCpf",
                table: "Voo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voo_PassageiroCpf",
                table: "Voo",
                column: "PassageiroCpf");

            migrationBuilder.AddForeignKey(
                name: "FK_Voo_Passageiro_PassageiroCpf",
                table: "Voo",
                column: "PassageiroCpf",
                principalTable: "Passageiro",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
