using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstructurasPresupuestarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstructurasPresupuestarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuentesFinanciamiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuentesFinanciamiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cui = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuenteFinanciamientoId = table.Column<int>(type: "int", nullable: false),
                    EstructuraPresupuestariaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiarios_EstructurasPresupuestarias_EstructuraPresupuestariaId",
                        column: x => x.EstructuraPresupuestariaId,
                        principalTable: "EstructurasPresupuestarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiarios_FuentesFinanciamiento_FuenteFinanciamientoId",
                        column: x => x.FuenteFinanciamientoId,
                        principalTable: "FuentesFinanciamiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proposito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeneficiarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Beneficiarios_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "Beneficiarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosRespaldo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeneficiarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosRespaldo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentosRespaldo_Beneficiarios_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "Beneficiarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiarios_EstructuraPresupuestariaId",
                table: "Beneficiarios",
                column: "EstructuraPresupuestariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiarios_FuenteFinanciamientoId",
                table: "Beneficiarios",
                column: "FuenteFinanciamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_BeneficiarioId",
                table: "Cuentas",
                column: "BeneficiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosRespaldo_BeneficiarioId",
                table: "DocumentosRespaldo",
                column: "BeneficiarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "DocumentosRespaldo");

            migrationBuilder.DropTable(
                name: "Beneficiarios");

            migrationBuilder.DropTable(
                name: "EstructurasPresupuestarias");

            migrationBuilder.DropTable(
                name: "FuentesFinanciamiento");
        }
    }
}
