using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Beneficiario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cui { get; set; }
        public ICollection<CuentaBancaria>? Cuentas { get; set; } = new List<CuentaBancaria>();
        public int ?FuenteFinanciamientoId { get; set; }
        public FuenteFinanciamiento? FuenteFinanciamiento { get; set; }
        public int ?EstructuraPresupuestariaId { get; set; }
        public EstructuraPresupuestaria? EstructuraPresupuestaria { get; set; }
        public ICollection<DocumentosRespaldo>? DocumentosRespaldo { get; set; } = new List<DocumentosRespaldo>();
        public ICollection<Solicitud>? Solicitudes { get; set; } = new List<Solicitud>();
    }
}
