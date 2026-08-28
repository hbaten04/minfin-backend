using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record SolicitudDto(
        DateTime FechaCreacion,
        decimal Monto,
        string Moneda,
        BeneficiarioDto Beneficiario
    );

    public record SolicitudResponseDto(
        int Id,
        DateTime FechaCreacion,
        decimal Monto,
        string Moneda,
        BeneficiarioResponseDto Beneficiario
    );

}
