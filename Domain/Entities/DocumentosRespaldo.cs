using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DocumentosRespaldo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? BeneficiarioId { get; set; }
        public Beneficiario? Beneficiario { get; set; }
    }
}
