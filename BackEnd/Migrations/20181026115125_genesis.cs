using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeAluga.Migrations
{
    public partial class genesis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosCivis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCivis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataDeRegistro = table.Column<DateTime>(nullable: false),
                    Endereco_CEP = table.Column<string>(maxLength: 10, nullable: true),
                    Endereco_Logradouro = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_Numero = table.Column<string>(maxLength: 10, nullable: true),
                    Endereco_Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_Complemento = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_Estado = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locatarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    RG = table.Column<string>(maxLength: 20, nullable: true),
                    Nacionalidade = table.Column<string>(maxLength: 50, nullable: true),
                    Profissao = table.Column<string>(maxLength: 50, nullable: true),
                    EstadoCivilId = table.Column<int>(nullable: false),
                    Telefone = table.Column<string>(maxLength: 15, nullable: true),
                    DataDeRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locatarios_EstadosCivis_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadosCivis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocatarioId = table.Column<int>(nullable: false),
                    ImovelId = table.Column<int>(nullable: false),
                    DataDeRegistro = table.Column<DateTime>(nullable: false),
                    DataDeInicio = table.Column<DateTime>(nullable: false),
                    DataDeTermino = table.Column<DateTime>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Locatarios_LocatarioId",
                        column: x => x.LocatarioId,
                        principalTable: "Locatarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aluguel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vencimento = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    ValorPago = table.Column<decimal>(nullable: true),
                    DataDePagamento = table.Column<DateTime>(nullable: true),
                    Observacao = table.Column<string>(maxLength: 500, nullable: true),
                    ContratoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluguel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluguel_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Garantia",
                columns: table => new
                {
                    ContratoId = table.Column<int>(nullable: false),
                    valorCaucao = table.Column<decimal>(nullable: true),
                    DataDeRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garantia", x => x.ContratoId);
                    table.ForeignKey(
                        name: "FK_Garantia_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fiador",
                columns: table => new
                {
                    GarantiaId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    RG = table.Column<string>(maxLength: 20, nullable: true),
                    DataDeRegistro = table.Column<DateTime>(nullable: false),
                    Endereco_CEP = table.Column<string>(maxLength: 10, nullable: true),
                    Endereco_Logradouro = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_Numero = table.Column<string>(maxLength: 10, nullable: true),
                    Endereco_Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_Complemento = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_Estado = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiador", x => x.GarantiaId);
                    table.ForeignKey(
                        name: "FK_Fiador_Garantia_GarantiaId",
                        column: x => x.GarantiaId,
                        principalTable: "Garantia",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluguel_ContratoId",
                table: "Aluguel",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ImovelId",
                table: "Contratos",
                column: "ImovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_LocatarioId",
                table: "Contratos",
                column: "LocatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Locatarios_EstadoCivilId",
                table: "Locatarios",
                column: "EstadoCivilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluguel");

            migrationBuilder.DropTable(
                name: "Fiador");

            migrationBuilder.DropTable(
                name: "Garantia");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Imoveis");

            migrationBuilder.DropTable(
                name: "Locatarios");

            migrationBuilder.DropTable(
                name: "EstadosCivis");
        }
    }
}
