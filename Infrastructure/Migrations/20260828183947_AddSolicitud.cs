using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSolicitud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiarios_EstructurasPresupuestarias_EstructuraPresupuestariaId",
                table: "Beneficiarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiarios_FuentesFinanciamiento_FuenteFinanciamientoId",
                table: "Beneficiarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Beneficiarios_BeneficiarioId",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentosRespaldo_Beneficiarios_BeneficiarioId",
                table: "DocumentosRespaldo");

            migrationBuilder.AlterColumn<int>(
                name: "BeneficiarioId",
                table: "DocumentosRespaldo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BeneficiarioId",
                table: "Cuentas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FuenteFinanciamientoId",
                table: "Beneficiarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EstructuraPresupuestariaId",
                table: "Beneficiarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeneficiarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitud_Beneficiarios_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "Beneficiarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_BeneficiarioId",
                table: "Solicitud",
                column: "BeneficiarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiarios_EstructurasPresupuestarias_EstructuraPresupuestariaId",
                table: "Beneficiarios",
                column: "EstructuraPresupuestariaId",
                principalTable: "EstructurasPresupuestarias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiarios_FuentesFinanciamiento_FuenteFinanciamientoId",
                table: "Beneficiarios",
                column: "FuenteFinanciamientoId",
                principalTable: "FuentesFinanciamiento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Beneficiarios_BeneficiarioId",
                table: "Cuentas",
                column: "BeneficiarioId",
                principalTable: "Beneficiarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentosRespaldo_Beneficiarios_BeneficiarioId",
                table: "DocumentosRespaldo",
                column: "BeneficiarioId",
                principalTable: "Beneficiarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiarios_EstructurasPresupuestarias_EstructuraPresupuestariaId",
                table: "Beneficiarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiarios_FuentesFinanciamiento_FuenteFinanciamientoId",
                table: "Beneficiarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Beneficiarios_BeneficiarioId",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentosRespaldo_Beneficiarios_BeneficiarioId",
                table: "DocumentosRespaldo");

            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.AlterColumn<int>(
                name: "BeneficiarioId",
                table: "DocumentosRespaldo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BeneficiarioId",
                table: "Cuentas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuenteFinanciamientoId",
                table: "Beneficiarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstructuraPresupuestariaId",
                table: "Beneficiarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiarios_EstructurasPresupuestarias_EstructuraPresupuestariaId",
                table: "Beneficiarios",
                column: "EstructuraPresupuestariaId",
                principalTable: "EstructurasPresupuestarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiarios_FuentesFinanciamiento_FuenteFinanciamientoId",
                table: "Beneficiarios",
                column: "FuenteFinanciamientoId",
                principalTable: "FuentesFinanciamiento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Beneficiarios_BeneficiarioId",
                table: "Cuentas",
                column: "BeneficiarioId",
                principalTable: "Beneficiarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentosRespaldo_Beneficiarios_BeneficiarioId",
                table: "DocumentosRespaldo",
                column: "BeneficiarioId",
                principalTable: "Beneficiarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
