using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lugiaweather_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_ALERTA",
                columns: table => new
                {
                    id_alerta = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    tipo = table.Column<int>(type: "NUMBER(10)", maxLength: 50, nullable: false),
                    mensagem = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    data_criacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ALERTA", x => x.id_alerta);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ENDERECO",
                columns: table => new
                {
                    id_endereco = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    logradouro = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    bairro = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    complemento = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    uf = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false),
                    localidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    latitude = table.Column<decimal>(type: "NUMERIC(10,6)", nullable: true),
                    longitude = table.Column<decimal>(type: "NUMERIC(11,6)", nullable: true),
                    data_criacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "SYSTIMESTAMP"),
                    data_atualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ENDERECO", x => x.id_endereco);
                });

            migrationBuilder.CreateTable(
                name: "TBL_DISPOSITIVO_IOT",
                columns: table => new
                {
                    id_dispositivo = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_modulo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    mac_endereco = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    projeto = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_endereco = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "SYSTIMESTAMP"),
                    data_atualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_DISPOSITIVO_IOT", x => x.id_dispositivo);
                    table.ForeignKey(
                        name: "FK_TBL_DISPOSITIVO_IOT_TBL_ENDERECO_id_endereco",
                        column: x => x.id_endereco,
                        principalTable: "TBL_ENDERECO",
                        principalColumn: "id_endereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LEITURA",
                columns: table => new
                {
                    id_leitura = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_dispositivo = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    nivel_agua_cm = table.Column<decimal>(type: "NUMERIC(8,3)", nullable: false),
                    status_nivel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    id_alerta = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LEITURA", x => x.id_leitura);
                    table.ForeignKey(
                        name: "FK_TBL_LEITURA_TBL_ALERTA_id_alerta",
                        column: x => x.id_alerta,
                        principalTable: "TBL_ALERTA",
                        principalColumn: "id_alerta");
                    table.ForeignKey(
                        name: "FK_TBL_LEITURA_TBL_DISPOSITIVO_IOT_id_dispositivo",
                        column: x => x.id_dispositivo,
                        principalTable: "TBL_DISPOSITIVO_IOT",
                        principalColumn: "id_dispositivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_DISPOSITIVO_IOT_id_endereco",
                table: "TBL_DISPOSITIVO_IOT",
                column: "id_endereco");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_LEITURA_id_alerta",
                table: "TBL_LEITURA",
                column: "id_alerta");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_LEITURA_id_dispositivo",
                table: "TBL_LEITURA",
                column: "id_dispositivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_LEITURA");

            migrationBuilder.DropTable(
                name: "TBL_ALERTA");

            migrationBuilder.DropTable(
                name: "TBL_DISPOSITIVO_IOT");

            migrationBuilder.DropTable(
                name: "TBL_ENDERECO");
        }
    }
}
