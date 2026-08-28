using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBeneficiarioRepository
    {
        Task<IEnumerable<Beneficiario>> GetAllAsync();
        Task<Beneficiario?> GetByIdAsync(int id);
        Task<Beneficiario> AddAsync(Beneficiario beneficiario);
        Task<bool> UpdateAsync(Beneficiario beneficiario);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}

