using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lugiaweather_api.Migrations
{
    /// <inheritdoc />
    public partial class AjusteColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_DISPOSITIVO_IOT_TBL_ENDERECO_id_endereco",
                table: "TBL_DISPOSITIVO_IOT");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_LEITURA_TBL_ALERTA_id_alerta",
                table: "TBL_LEITURA");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_LEITURA_TBL_DISPOSITIVO_IOT_id_dispositivo",
                table: "TBL_LEITURA");

            migrationBuilder.RenameColumn(
                name: "status_nivel",
                table: "TBL_LEITURA",
                newName: "STATUS_NIVEL");

            migrationBuilder.RenameColumn(
                name: "nivel_agua_cm",
                table: "TBL_LEITURA",
                newName: "NIVEL_AGUA_CM");

            migrationBuilder.RenameColumn(
                name: "id_dispositivo",
                table: "TBL_LEITURA",
                newName: "ID_DISPOSITIVO");

            migrationBuilder.RenameColumn(
                name: "id_alerta",
                table: "TBL_LEITURA",
                newName: "ID_ALERTA");

            migrationBuilder.RenameColumn(
                name: "data_criacao",
                table: "TBL_LEITURA",
                newName: "DATA_CRIACAO");

            migrationBuilder.RenameColumn(
                name: "id_leitura",
                table: "TBL_LEITURA",
                newName: "ID_LEITURA");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_LEITURA_id_dispositivo",
                table: "TBL_LEITURA",
                newName: "IX_TBL_LEITURA_ID_DISPOSITIVO");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_LEITURA_id_alerta",
                table: "TBL_LEITURA",
                newName: "IX_TBL_LEITURA_ID_ALERTA");

            migrationBuilder.RenameColumn(
                name: "uf",
                table: "TBL_ENDERECO",
                newName: "UF");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "TBL_ENDERECO",
                newName: "LONGITUDE");

            migrationBuilder.RenameColumn(
                name: "logradouro",
                table: "TBL_ENDERECO",
                newName: "LOGRADOURO");

            migrationBuilder.RenameColumn(
                name: "localidade",
                table: "TBL_ENDERECO",
                newName: "LOCALIDADE");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "TBL_ENDERECO",
                newName: "LATITUDE");

            migrationBuilder.RenameColumn(
                name: "data_criacao",
                table: "TBL_ENDERECO",
                newName: "DATA_CRIACAO");

            migrationBuilder.RenameColumn(
                name: "data_atualizacao",
                table: "TBL_ENDERECO",
                newName: "DATA_ATUALIZACAO");

            migrationBuilder.RenameColumn(
                name: "complemento",
                table: "TBL_ENDERECO",
                newName: "COMPLEMENTO");

            migrationBuilder.RenameColumn(
                name: "bairro",
                table: "TBL_ENDERECO",
                newName: "BAIRRO");

            migrationBuilder.RenameColumn(
                name: "id_endereco",
                table: "TBL_ENDERECO",
                newName: "ID_ENDERECO");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "projeto",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "PROJETO");

            migrationBuilder.RenameColumn(
                name: "mac_endereco",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "MAC_ENDERECO");

            migrationBuilder.RenameColumn(
                name: "id_modulo",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "ID_MODULO");

            migrationBuilder.RenameColumn(
                name: "id_endereco",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "ID_ENDERECO");

            migrationBuilder.RenameColumn(
                name: "data_criacao",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "DATA_CRIACAO");

            migrationBuilder.RenameColumn(
                name: "data_atualizacao",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "DATA_ATUALIZACAO");

            migrationBuilder.RenameColumn(
                name: "id_dispositivo",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "ID_DISPOSITIVO");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_DISPOSITIVO_IOT_id_endereco",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "IX_TBL_DISPOSITIVO_IOT_ID_ENDERECO");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "TBL_ALERTA",
                newName: "TIPO");

            migrationBuilder.RenameColumn(
                name: "mensagem",
                table: "TBL_ALERTA",
                newName: "MENSAGEM");

            migrationBuilder.RenameColumn(
                name: "data_criacao",
                table: "TBL_ALERTA",
                newName: "DATA_CRIACAO");

            migrationBuilder.RenameColumn(
                name: "id_alerta",
                table: "TBL_ALERTA",
                newName: "ID_ALERTA");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA_CRIACAO",
                table: "TBL_LEITURA",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYSTIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA_CRIACAO",
                table: "TBL_ALERTA",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValueSql: "SYSTIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_DISPOSITIVO_IOT_TBL_ENDERECO_ID_ENDERECO",
                table: "TBL_DISPOSITIVO_IOT",
                column: "ID_ENDERECO",
                principalTable: "TBL_ENDERECO",
                principalColumn: "ID_ENDERECO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_LEITURA_TBL_ALERTA_ID_ALERTA",
                table: "TBL_LEITURA",
                column: "ID_ALERTA",
                principalTable: "TBL_ALERTA",
                principalColumn: "ID_ALERTA");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_LEITURA_TBL_DISPOSITIVO_IOT_ID_DISPOSITIVO",
                table: "TBL_LEITURA",
                column: "ID_DISPOSITIVO",
                principalTable: "TBL_DISPOSITIVO_IOT",
                principalColumn: "ID_DISPOSITIVO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_DISPOSITIVO_IOT_TBL_ENDERECO_ID_ENDERECO",
                table: "TBL_DISPOSITIVO_IOT");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_LEITURA_TBL_ALERTA_ID_ALERTA",
                table: "TBL_LEITURA");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_LEITURA_TBL_DISPOSITIVO_IOT_ID_DISPOSITIVO",
                table: "TBL_LEITURA");

            migrationBuilder.RenameColumn(
                name: "STATUS_NIVEL",
                table: "TBL_LEITURA",
                newName: "status_nivel");

            migrationBuilder.RenameColumn(
                name: "NIVEL_AGUA_CM",
                table: "TBL_LEITURA",
                newName: "nivel_agua_cm");

            migrationBuilder.RenameColumn(
                name: "ID_DISPOSITIVO",
                table: "TBL_LEITURA",
                newName: "id_dispositivo");

            migrationBuilder.RenameColumn(
                name: "ID_ALERTA",
                table: "TBL_LEITURA",
                newName: "id_alerta");

            migrationBuilder.RenameColumn(
                name: "DATA_CRIACAO",
                table: "TBL_LEITURA",
                newName: "data_criacao");

            migrationBuilder.RenameColumn(
                name: "ID_LEITURA",
                table: "TBL_LEITURA",
                newName: "id_leitura");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_LEITURA_ID_DISPOSITIVO",
                table: "TBL_LEITURA",
                newName: "IX_TBL_LEITURA_id_dispositivo");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_LEITURA_ID_ALERTA",
                table: "TBL_LEITURA",
                newName: "IX_TBL_LEITURA_id_alerta");

            migrationBuilder.RenameColumn(
                name: "UF",
                table: "TBL_ENDERECO",
                newName: "uf");

            migrationBuilder.RenameColumn(
                name: "LONGITUDE",
                table: "TBL_ENDERECO",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "LOGRADOURO",
                table: "TBL_ENDERECO",
                newName: "logradouro");

            migrationBuilder.RenameColumn(
                name: "LOCALIDADE",
                table: "TBL_ENDERECO",
                newName: "localidade");

            migrationBuilder.RenameColumn(
                name: "LATITUDE",
                table: "TBL_ENDERECO",
                newName: "latitude");

            migrationBuilder.RenameColumn(
                name: "DATA_CRIACAO",
                table: "TBL_ENDERECO",
                newName: "data_criacao");

            migrationBuilder.RenameColumn(
                name: "DATA_ATUALIZACAO",
                table: "TBL_ENDERECO",
                newName: "data_atualizacao");

            migrationBuilder.RenameColumn(
                name: "COMPLEMENTO",
                table: "TBL_ENDERECO",
                newName: "complemento");

            migrationBuilder.RenameColumn(
                name: "BAIRRO",
                table: "TBL_ENDERECO",
                newName: "bairro");

            migrationBuilder.RenameColumn(
                name: "ID_ENDERECO",
                table: "TBL_ENDERECO",
                newName: "id_endereco");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "PROJETO",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "projeto");

            migrationBuilder.RenameColumn(
                name: "MAC_ENDERECO",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "mac_endereco");

            migrationBuilder.RenameColumn(
                name: "ID_MODULO",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "id_modulo");

            migrationBuilder.RenameColumn(
                name: "ID_ENDERECO",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "id_endereco");

            migrationBuilder.RenameColumn(
                name: "DATA_CRIACAO",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "data_criacao");

            migrationBuilder.RenameColumn(
                name: "DATA_ATUALIZACAO",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "data_atualizacao");

            migrationBuilder.RenameColumn(
                name: "ID_DISPOSITIVO",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "id_dispositivo");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_DISPOSITIVO_IOT_ID_ENDERECO",
                table: "TBL_DISPOSITIVO_IOT",
                newName: "IX_TBL_DISPOSITIVO_IOT_id_endereco");

            migrationBuilder.RenameColumn(
                name: "TIPO",
                table: "TBL_ALERTA",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "MENSAGEM",
                table: "TBL_ALERTA",
                newName: "mensagem");

            migrationBuilder.RenameColumn(
                name: "DATA_CRIACAO",
                table: "TBL_ALERTA",
                newName: "data_criacao");

            migrationBuilder.RenameColumn(
                name: "ID_ALERTA",
                table: "TBL_ALERTA",
                newName: "id_alerta");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "TBL_LEITURA",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYSTIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "TBL_ALERTA",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldDefaultValueSql: "SYSTIMESTAMP");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_DISPOSITIVO_IOT_TBL_ENDERECO_id_endereco",
                table: "TBL_DISPOSITIVO_IOT",
                column: "id_endereco",
                principalTable: "TBL_ENDERECO",
                principalColumn: "id_endereco",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_LEITURA_TBL_ALERTA_id_alerta",
                table: "TBL_LEITURA",
                column: "id_alerta",
                principalTable: "TBL_ALERTA",
                principalColumn: "id_alerta");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_LEITURA_TBL_DISPOSITIVO_IOT_id_dispositivo",
                table: "TBL_LEITURA",
                column: "id_dispositivo",
                principalTable: "TBL_DISPOSITIVO_IOT",
                principalColumn: "id_dispositivo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
