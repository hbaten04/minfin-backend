using Application.DTOs;
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

        public async Task<IEnumerable<SolicitudResponseDto>> GetAllAsync()
        {
            var solicitudes = await _repository.GetAllAsync();
            return solicitudes.Select(MapToResponseDto);
        }

        private static SolicitudResponseDto MapToResponseDto(Solicitud s)
        {
            return new SolicitudResponseDto(
                s.Id,
                s.FechaCreacion,
                s.Monto,
                s.Moneda,
                new BeneficiarioResponseDto(
                    s.Beneficiario.Id,
                    s.Beneficiario.Nombre,
                    s.Beneficiario.Apellido,
                    s.Beneficiario.Cui,
                    s.Beneficiario.FuenteFinanciamiento != null
                        ? new FuenteFinanciamientoDto(s.Beneficiario.FuenteFinanciamiento.Id, s.Beneficiario.FuenteFinanciamiento.Descripcion)
                        : null,
                    s.Beneficiario.EstructuraPresupuestaria != null
                        ? new EstructuraPresupuestariaDto(s.Beneficiario.EstructuraPresupuestaria.Id, s.Beneficiario.EstructuraPresupuestaria.Descripcion)
                        : null,
                    s.Beneficiario.Cuentas.Select(c => new CuentaResponseDto(c.Id, c.NumeroCuenta, c.Proposito)).ToList(),
                    s.Beneficiario.DocumentosRespaldo.Select(d => new DocumentoRespaldoResponseDto(d.Id, d.Descripcion)).ToList()
                )
            );
        }


        public async Task<Solicitud?> GetByIdAsync(int id)
        {
            var solicitud = await _repository.GetByIdAsync(id);

            return solicitud is null ? null : solicitud;
        }
    }
}
