using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Caregivers.Infra.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUIDADOR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NOME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    SEXO = table.Column<int>(type: "integer", nullable: false),
                    FOTO = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BIOGRAFIA = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    WHATSAPP = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ATIVO = table.Column<bool>(type: "boolean", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DATA_DESATIVACAO = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUIDADOR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PAIS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NOME = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAIS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CONTATO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    DATA = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ID_CUIDADOR = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTATO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTATO_CUIDADOR_ID_CUIDADOR",
                        column: x => x.ID_CUIDADOR,
                        principalTable: "CUIDADOR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ESTADO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NOME = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ID_PAIS = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ESTADO_PAIS_ID_PAIS",
                        column: x => x.ID_PAIS,
                        principalTable: "PAIS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CIDADE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NOME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ID_ESTADO = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIDADE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CIDADE_ESTADO_ID_ESTADO",
                        column: x => x.ID_ESTADO,
                        principalTable: "ESTADO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUIDADOR_CIDADE",
                columns: table => new
                {
                    ID_CUIDADOR = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_CIDADE = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUIDADOR_CIDADE", x => new { x.ID_CIDADE, x.ID_CUIDADOR });
                    table.ForeignKey(
                        name: "FK_CUIDADOR_CIDADE_CIDADE_ID_CIDADE",
                        column: x => x.ID_CIDADE,
                        principalTable: "CIDADE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CUIDADOR_CIDADE_CUIDADOR_ID_CUIDADOR",
                        column: x => x.ID_CUIDADOR,
                        principalTable: "CUIDADOR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PAIS",
                columns: new[] { "ID", "NOME" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "Brasil" });

            migrationBuilder.InsertData(
                table: "ESTADO",
                columns: new[] { "ID", "ID_PAIS", "NOME" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "Minas Gerais" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), "Rio de Janeiro" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001"), "São Paulo" }
                });

            migrationBuilder.InsertData(
                table: "CIDADE",
                columns: new[] { "ID", "ID_ESTADO", "NOME" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "Belo Horizonte" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), "Nova Lima" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001"), "Divinópolis" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001"), "Rio Acima" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001"), "Ouro Preto" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001"), "Itabirito" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CIDADE_ID_ESTADO",
                table: "CIDADE",
                column: "ID_ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_CONTATO_ID_CUIDADOR",
                table: "CONTATO",
                column: "ID_CUIDADOR");

            migrationBuilder.CreateIndex(
                name: "IX_CUIDADOR_CIDADE_ID_CUIDADOR",
                table: "CUIDADOR_CIDADE",
                column: "ID_CUIDADOR");

            migrationBuilder.CreateIndex(
                name: "IX_ESTADO_ID_PAIS",
                table: "ESTADO",
                column: "ID_PAIS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTATO");

            migrationBuilder.DropTable(
                name: "CUIDADOR_CIDADE");

            migrationBuilder.DropTable(
                name: "CIDADE");

            migrationBuilder.DropTable(
                name: "CUIDADOR");

            migrationBuilder.DropTable(
                name: "ESTADO");

            migrationBuilder.DropTable(
                name: "PAIS");
        }
    }
}
