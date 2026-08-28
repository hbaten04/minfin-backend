using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBeneficiarioService
    {
        Task<IEnumerable<Beneficiario>> GetAllAsync();
        Task<Beneficiario?> GetByIdAsync(int id);
        Task<Beneficiario> CreateAsync(Beneficiario beneficiario);
        Task<bool> UpdateAsync(Beneficiario beneficiario);
        Task<bool> DeleteAsync(int id);
    }
}
