using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BeneficiarioService : IBeneficiarioService
    {
        private readonly IBeneficiarioRepository _repository;
        public BeneficiarioService(IBeneficiarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<Beneficiario> CreateAsync(Beneficiario beneficiario)
        {

            var creado = await _repository.AddAsync(beneficiario);
            return creado;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Beneficiario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Beneficiario?> GetByIdAsync(int id)
        {
            var beneficiario = await _repository.GetByIdAsync(id);
            return beneficiario is null ? null : beneficiario;
        }

        public Task<bool> UpdateAsync(Beneficiario beneficiario)
        {
            throw new NotImplementedException();
        }
    }
}
