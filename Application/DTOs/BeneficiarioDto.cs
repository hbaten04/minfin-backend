using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record BeneficiarioDto(
        string Nombre,
        string Apellido,
        string Cui,
        int? FuenteFinanciamientoId,
        int? EstructuraPresupuestariaId,
        List<CuentaDto> Cuentas,
        List<DocumentoRespaldoDto> DocumentosRespaldo
    );

    public record CuentaDto(
        string NumeroCuenta,
        string Proposito
    );

    public record DocumentoRespaldoDto(
        string Descripcion
    );
    public record BeneficiarioResponseDto(
        int Id,
        string Nombre,
        string Apellido,
        string Cui,
        FuenteFinanciamientoDto? FuenteFinanciamiento,
        EstructuraPresupuestariaDto? EstructuraPresupuestaria,
        List<CuentaResponseDto>? Cuentas,
        List<DocumentoRespaldoResponseDto>? DocumentosRespaldo
    );

    public record CuentaResponseDto(
        int Id,
        string NumeroCuenta,
        string Proposito
    );

    public record DocumentoRespaldoResponseDto(
        int Id,
        string Descripcion
    );

    public record FuenteFinanciamientoDto(
        int Id,
        string Descripcion
    );

    public record EstructuraPresupuestariaDto(
        int Id,
        string Descripcion
    );

}
