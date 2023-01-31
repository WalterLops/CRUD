using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeVale.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Atendente",
                columns: table => new
                {
                    Id_Atendente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendente", x => x.Id_Atendente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bicicleta",
                columns: table => new
                {
                    Id_Bicicleta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Modelo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modalidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QteMarchas = table.Column<int>(name: "Qte-Marchas", type: "int", nullable: false),
                    StatusEmprestimo = table.Column<int>(name: "Status-Emprestimo", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicicleta", x => x.Id_Bicicleta);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_Cliente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    Id_Historico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataAlugel = table.Column<DateTime>(name: "Data-Alugel", type: "datetime(6)", nullable: false),
                    TempoAluguel = table.Column<int>(name: "Tempo-Aluguel", type: "int", nullable: false),
                    LocalPasseio = table.Column<string>(name: "Local-Passeio", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => x.Id_Historico);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Manutancao",
                columns: table => new
                {
                    Id_Manutencao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<double>(type: "double", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutancao", x => x.Id_Manutencao);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aluga",
                columns: table => new
                {
                    Id_Aluga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdBicicleta = table.Column<int>(type: "int", nullable: false),
                    IdHistorico = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdAtendente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluga", x => x.Id_Aluga);
                    table.ForeignKey(
                        name: "FK_Aluga_Atendente_IdAtendente",
                        column: x => x.IdAtendente,
                        principalTable: "Atendente",
                        principalColumn: "Id_Atendente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aluga_Bicicleta_IdBicicleta",
                        column: x => x.IdBicicleta,
                        principalTable: "Bicicleta",
                        principalColumn: "Id_Bicicleta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aluga_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aluga_Historico_IdHistorico",
                        column: x => x.IdHistorico,
                        principalTable: "Historico",
                        principalColumn: "Id_Historico",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Possui",
                columns: table => new
                {
                    Id_Possui = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Atendente = table.Column<int>(type: "int", nullable: false),
                    Id_Manutencao = table.Column<int>(type: "int", nullable: false),
                    Id_Bicicleta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possui", x => x.Id_Possui);
                    table.ForeignKey(
                        name: "FK_Possui_Atendente_Id_Atendente",
                        column: x => x.Id_Atendente,
                        principalTable: "Atendente",
                        principalColumn: "Id_Atendente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Possui_Bicicleta_Id_Bicicleta",
                        column: x => x.Id_Bicicleta,
                        principalTable: "Bicicleta",
                        principalColumn: "Id_Bicicleta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Possui_Manutancao_Id_Manutencao",
                        column: x => x.Id_Manutencao,
                        principalTable: "Manutancao",
                        principalColumn: "Id_Manutencao",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Aluga_IdAtendente",
                table: "Aluga",
                column: "IdAtendente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluga_IdBicicleta",
                table: "Aluga",
                column: "IdBicicleta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluga_IdCliente",
                table: "Aluga",
                column: "IdCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluga_IdHistorico",
                table: "Aluga",
                column: "IdHistorico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Possui_Id_Atendente",
                table: "Possui",
                column: "Id_Atendente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Possui_Id_Bicicleta",
                table: "Possui",
                column: "Id_Bicicleta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Possui_Id_Manutencao",
                table: "Possui",
                column: "Id_Manutencao",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluga");

            migrationBuilder.DropTable(
                name: "Possui");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Historico");

            migrationBuilder.DropTable(
                name: "Atendente");

            migrationBuilder.DropTable(
                name: "Bicicleta");

            migrationBuilder.DropTable(
                name: "Manutancao");
        }
    }
}
