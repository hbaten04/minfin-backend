using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correcioncascadabeneficiario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Solicitud_BeneficiarioId",
                table: "Solicitud");

            migrationBuilder.AddColumn<int>(
                name: "BeneficiarioId1",
                table: "Solicitud",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_BeneficiarioId",
                table: "Solicitud",
                column: "BeneficiarioId",
                unique: true,
                filter: "[BeneficiarioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_BeneficiarioId1",
                table: "Solicitud",
                column: "BeneficiarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_Beneficiarios_BeneficiarioId1",
                table: "Solicitud",
                column: "BeneficiarioId1",
                principalTable: "Beneficiarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_Beneficiarios_BeneficiarioId1",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_BeneficiarioId",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_BeneficiarioId1",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "BeneficiarioId1",
                table: "Solicitud");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_BeneficiarioId",
                table: "Solicitud",
                column: "BeneficiarioId");
        }
    }
}
