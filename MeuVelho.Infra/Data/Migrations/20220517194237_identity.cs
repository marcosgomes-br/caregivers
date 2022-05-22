using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MeuVelho.Infra.Data.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.EnsureSchema(
                name: "IDENTITY");

            migrationBuilder.CreateTable(
                name: "CAREGIVER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    FULL_NAME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    GENDER = table.Column<int>(type: "integer", nullable: false),
                    PHOTO = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BIOGRAPHY = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    WHATSAPP = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ACTIVE = table.Column<bool>(type: "boolean", nullable: false),
                    REGISTER_IN = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DISABLED_IN = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAREGIVER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRY",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NAME = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                schema: "IDENTITY",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NAME = table.Column<string>(type: "text", nullable: true),
                    NORMALIZED_NAME = table.Column<string>(type: "text", nullable: true),
                    CONCURRENCY_STAMP = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                schema: "IDENTITY",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    USER_NAME = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    NORMALIZED_USER_NAME = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    EMAIL = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NORMALIZED_EMAIL = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    EMAIL_CONFIRMED = table.Column<bool>(type: "boolean", nullable: false),
                    PASSWORD = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    SECURITY_STAMP = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CONCURRENCY_STAMP = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PHONE_NUMBER_CONFIRMED = table.Column<bool>(type: "boolean", nullable: false),
                    TWO_FACTOR_ENABLED = table.Column<bool>(type: "boolean", nullable: false),
                    LOCKOUT_END = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LOCKOUT_ENABLED = table.Column<bool>(type: "boolean", nullable: false),
                    ACCESS_FAILED_COUNT = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_CLAIM",
                schema: "IDENTITY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_USER = table.Column<Guid>(type: "uuid", nullable: false),
                    CLAIM_TYPE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CLAIM_VALUE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_CLAIM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CONNECTION",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ID_CAREGIVER = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONNECTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONNECTION_CAREGIVER_ID_CAREGIVER",
                        column: x => x.ID_CAREGIVER,
                        principalTable: "CAREGIVER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STATE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NAME = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ID_COUNTRY = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STATE_COUNTRY_ID_COUNTRY",
                        column: x => x.ID_COUNTRY,
                        principalTable: "COUNTRY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ROLE_CLAIM",
                schema: "IDENTITY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_ROLE = table.Column<Guid>(type: "uuid", nullable: false),
                    CLAIM_TYPE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CLAIM_VALUE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_CLAIM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ROLE_CLAIM_ROLE_ID_ROLE",
                        column: x => x.ID_ROLE,
                        principalSchema: "IDENTITY",
                        principalTable: "ROLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LOGIN",
                schema: "IDENTITY",
                columns: table => new
                {
                    LOGIN_PROVIDER = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    PROVIDER_KEY = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PROVIDER_DISPLAY_NAME = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ID_USER = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_LOGIN_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalSchema: "IDENTITY",
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_ROLE",
                schema: "IDENTITY",
                columns: table => new
                {
                    ID_USER = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_ROLE = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_USER_ROLE_ROLE_ID_ROLE",
                        column: x => x.ID_ROLE,
                        principalSchema: "IDENTITY",
                        principalTable: "ROLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_ROLE_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalSchema: "IDENTITY",
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_TOKEN",
                schema: "IDENTITY",
                columns: table => new
                {
                    ID_USER = table.Column<Guid>(type: "uuid", nullable: false),
                    LOGIN_PROVIDER = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    NAME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    VALUE = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_USER_TOKEN_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalSchema: "IDENTITY",
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NAME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ID_STATE = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CITY_STATE_ID_STATE",
                        column: x => x.ID_STATE,
                        principalTable: "STATE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CAREGIVER_CITY",
                columns: table => new
                {
                    ID_CAREGIVER = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_CITY = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAREGIVER_CITY", x => new { x.ID_CAREGIVER, x.ID_CITY });
                    table.ForeignKey(
                        name: "FK_CAREGIVER_CITY_CAREGIVER_ID_CAREGIVER",
                        column: x => x.ID_CAREGIVER,
                        principalTable: "CAREGIVER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CAREGIVER_CITY_CITY_ID_CITY",
                        column: x => x.ID_CITY,
                        principalTable: "CITY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "COUNTRY",
                columns: new[] { "ID", "NAME" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "Brasil" });

            migrationBuilder.InsertData(
                table: "STATE",
                columns: new[] { "ID", "ID_COUNTRY", "NAME" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "Minas Gerais" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), "Rio de Janeiro" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001"), "São Paulo" }
                });

            migrationBuilder.InsertData(
                table: "CITY",
                columns: new[] { "ID", "ID_STATE", "NAME" },
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
                name: "IX_CAREGIVER_CITY_ID_CITY",
                table: "CAREGIVER_CITY",
                column: "ID_CITY");

            migrationBuilder.CreateIndex(
                name: "IX_CITY_ID_STATE",
                table: "CITY",
                column: "ID_STATE");

            migrationBuilder.CreateIndex(
                name: "IX_CONNECTION_ID_CAREGIVER",
                table: "CONNECTION",
                column: "ID_CAREGIVER");

            migrationBuilder.CreateIndex(
                name: "IX_LOGIN_ID_USER",
                schema: "IDENTITY",
                table: "LOGIN",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_CLAIM_ID_ROLE",
                schema: "IDENTITY",
                table: "ROLE_CLAIM",
                column: "ID_ROLE");

            migrationBuilder.CreateIndex(
                name: "IX_STATE_ID_COUNTRY",
                table: "STATE",
                column: "ID_COUNTRY");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLE_ID_ROLE",
                schema: "IDENTITY",
                table: "USER_ROLE",
                column: "ID_ROLE");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLE_ID_USER",
                schema: "IDENTITY",
                table: "USER_ROLE",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_USER_TOKEN_ID_USER",
                schema: "IDENTITY",
                table: "USER_TOKEN",
                column: "ID_USER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAREGIVER_CITY");

            migrationBuilder.DropTable(
                name: "CONNECTION");

            migrationBuilder.DropTable(
                name: "LOGIN",
                schema: "IDENTITY");

            migrationBuilder.DropTable(
                name: "ROLE_CLAIM",
                schema: "IDENTITY");

            migrationBuilder.DropTable(
                name: "USER_CLAIM",
                schema: "IDENTITY");

            migrationBuilder.DropTable(
                name: "USER_ROLE",
                schema: "IDENTITY");

            migrationBuilder.DropTable(
                name: "USER_TOKEN",
                schema: "IDENTITY");

            migrationBuilder.DropTable(
                name: "CITY");

            migrationBuilder.DropTable(
                name: "CAREGIVER");

            migrationBuilder.DropTable(
                name: "ROLE",
                schema: "IDENTITY");

            migrationBuilder.DropTable(
                name: "USER",
                schema: "IDENTITY");

            migrationBuilder.DropTable(
                name: "STATE");

            migrationBuilder.DropTable(
                name: "COUNTRY");

            migrationBuilder.CreateTable(
                name: "CUIDADOR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ATIVO = table.Column<bool>(type: "boolean", nullable: false),
                    BIOGRAFIA = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DATA_DESATIVACAO = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FOTO = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    NOME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    SEXO = table.Column<int>(type: "integer", nullable: false),
                    WHATSAPP = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
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
                    ID_PAIS = table.Column<Guid>(type: "uuid", nullable: false),
                    NOME = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
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
                    ID_ESTADO = table.Column<Guid>(type: "uuid", nullable: false),
                    NOME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
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
                    ID_CIDADE = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_CUIDADOR = table.Column<Guid>(type: "uuid", nullable: false)
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
    }
}
