using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Solicitud
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public decimal Monto { get; set; }
        public string Moneda { get; set; }

        public int? BeneficiarioId { get; set; }

        public Beneficiario? Beneficiario { get; set; }
    }

}
