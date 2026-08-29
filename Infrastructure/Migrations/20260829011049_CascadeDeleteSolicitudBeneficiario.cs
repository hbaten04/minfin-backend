using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteSolicitudBeneficiario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_Beneficiarios_BeneficiarioId",
                table: "Solicitud");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_Beneficiarios_BeneficiarioId",
                table: "Solicitud",
                column: "BeneficiarioId",
                principalTable: "Beneficiarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_Beneficiarios_BeneficiarioId",
                table: "Solicitud");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_Beneficiarios_BeneficiarioId",
                table: "Solicitud",
                column: "BeneficiarioId",
                principalTable: "Beneficiarios",
                principalColumn: "Id");
        }
    }
}
