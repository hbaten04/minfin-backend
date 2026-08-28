using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CuentaBancaria
    {
        public int Id { get; set; }
        public string NumeroCuenta { get; set; }
        public string Proposito { get; set; }
        public int BeneficiarioId { get; set; }
        public Beneficiario Beneficiario { get; set; }

    }
}
