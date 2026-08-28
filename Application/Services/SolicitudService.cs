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
    public class SolicitudService : ISolicitudService
    {
        private readonly ISolicitudRepository _repository;
        private readonly IMessagePublisher _publisher;
        public SolicitudService(ISolicitudRepository repository, IMessagePublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }
        public async Task<Solicitud> CreateAsync(Solicitud solicitud)
        {
            var creada = await _repository.AddAsync(solicitud);
            await _publisher.PublishAsync("Solicitud_Creada", new
            {
                Id = Guid.NewGuid(),
                BeneficiarioId = solicitud.Id,
                Evento = "Solicitud creada"
            });
            return creada;
        }

        public async Task<Solicitud?> GetByIdAsync(int id)
        {
            var solicitud = await _repository.GetByIdAsync(id);

            return solicitud is null ? null : solicitud;
        }
    }
}
