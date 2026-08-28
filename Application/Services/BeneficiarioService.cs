using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BeneficiarioService : IBeneficiarioService
    {
        private readonly IBeneficiarioRepository _repository;
        private readonly IMessagePublisher _publisher;
        public BeneficiarioService(IBeneficiarioRepository repository, IMessagePublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }
        public async Task<Beneficiario> CreateAsync(Beneficiario beneficiario)
        {

            var creado = await _repository.AddAsync(beneficiario);
            await _publisher.PublishAsync("beneficiarios_creados", new
            {
                Id = Guid.NewGuid(),
                BeneficiarioId = beneficiario.Id,
                Evento = "Beneficiario creado"
            });
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
