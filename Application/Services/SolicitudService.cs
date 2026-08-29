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
        private readonly IBeneficiarioRepository _beneficiarioRepository;
        public SolicitudService(ISolicitudRepository repository, IMessagePublisher publisher, IBeneficiarioRepository beneficiarioRepository)
        {
            _repository = repository;
            _publisher = publisher;
            _beneficiarioRepository = beneficiarioRepository;
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
                        s.Beneficiario?.Id ?? 0,
                        s.Beneficiario?.Nombre ?? "",
                        s.Beneficiario?.Apellido ?? "",
                        s.Beneficiario?.Cui ?? "",
                        s.Beneficiario?.FuenteFinanciamiento != null
                            ? new FuenteFinanciamientoDto(s.Beneficiario.FuenteFinanciamiento.Id, s.Beneficiario.FuenteFinanciamiento.Descripcion)
                            : null,
                        s.Beneficiario?.EstructuraPresupuestaria != null
                            ? new EstructuraPresupuestariaDto(s.Beneficiario.EstructuraPresupuestaria.Id, s.Beneficiario.EstructuraPresupuestaria.Descripcion)
                            : null,
                        s.Beneficiario?.Cuentas?.Select(c => new CuentaResponseDto(c.Id, c.NumeroCuenta, c.Proposito)).ToList() ?? new List<CuentaResponseDto>(),
                        s.Beneficiario?.DocumentosRespaldo?.Select(d => new DocumentoRespaldoResponseDto(d.Id, d.Descripcion)).ToList() ?? new List<DocumentoRespaldoResponseDto>()
                )

            );
        }


        public async Task<Solicitud?> GetByIdAsync(int id)
        {
            var solicitud = await _repository.GetByIdAsync(id);

            return solicitud is null ? null : solicitud;
        }
        public async Task<SolicitudResponseDto?> UpdateAsync(int id, SolicitudDto dto)
        {
            var solicitud = await _repository.GetByIdAsync(id);
            if (solicitud == null) return null;

            // Actualizar Solicitud
            solicitud.Monto = dto.Monto;
            solicitud.Moneda = dto.Moneda;

            // Actualizar Beneficiario
            if (solicitud.Beneficiario != null && dto.Beneficiario != null)
            {
                solicitud.Beneficiario.Nombre = dto.Beneficiario.Nombre;
                solicitud.Beneficiario.Apellido = dto.Beneficiario.Apellido;
                solicitud.Beneficiario.Cui = dto.Beneficiario.Cui;
                solicitud.Beneficiario.FuenteFinanciamientoId = dto.Beneficiario.FuenteFinanciamientoId;
                solicitud.Beneficiario.EstructuraPresupuestariaId = dto.Beneficiario.EstructuraPresupuestariaId;

                // Actualizar cuentas existentes (sin tocar Id)
                foreach (var cuenta in solicitud.Beneficiario.Cuentas)
                {
                    var dtoCuenta = dto.Beneficiario.Cuentas
                        .FirstOrDefault(c => c.NumeroCuenta == cuenta.NumeroCuenta);

                    if (dtoCuenta != null)
                    {
                        cuenta.Proposito = dtoCuenta.Proposito;
                        // Id se conserva, no se toca
                    }
                }

                // Actualizar documentos existentes (sin tocar Id)
                foreach (var doc in solicitud.Beneficiario.DocumentosRespaldo)
                {
                    var dtoDoc = dto.Beneficiario.DocumentosRespaldo
                        .FirstOrDefault(d => d.Descripcion == doc.Descripcion);

                    if (dtoDoc != null)
                    {
                        doc.Descripcion = dtoDoc.Descripcion;
                        // Id se conserva, no se toca
                    }
                }
            }

            await _repository.UpdateAsync(solicitud);

            var actualizado = await _repository.GetByIdAsync(id);
            return MapToResponseDto(actualizado!);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var solicitud = await _repository.GetByIdAsync(id);
            if (solicitud == null) return false;

            // Eliminar la Solicitud primero
            await _repository.DeleteAsync(solicitud);

            // Luego eliminar el Beneficiario si existe
            if (solicitud.Beneficiario != null)
            {
                await _beneficiarioRepository.DeleteAsync(solicitud.Beneficiario);
            }

            return true;
        }





    }
}
