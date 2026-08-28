using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MINFIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly ISolicitudService _service;
        public SolicitudController(ISolicitudService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<SolicitudResponseDto>> CreateSolicitud([FromBody] SolicitudDto dto)
        {
            var solicitud = new Solicitud
            {
                FechaCreacion = dto.FechaCreacion,
                Monto = dto.Monto,
                Moneda = dto.Moneda,
                Beneficiario = new Beneficiario
                {
                    Nombre = dto.Beneficiario.Nombre,
                    Apellido = dto.Beneficiario.Apellido,
                    Cui = dto.Beneficiario.Cui,
                    FuenteFinanciamientoId = dto.Beneficiario.FuenteFinanciamientoId,
                    EstructuraPresupuestariaId = dto.Beneficiario.EstructuraPresupuestariaId,
                    Cuentas = dto.Beneficiario.Cuentas.Select(c => new CuentaBancaria
                    {
                        NumeroCuenta = c.NumeroCuenta,
                        Proposito = c.Proposito
                    }).ToList(),
                    DocumentosRespaldo = dto.Beneficiario.DocumentosRespaldo.Select(d => new DocumentosRespaldo
                    {
                        Descripcion = d.Descripcion
                    }).ToList()
                }
            };

            var creado = await _service.CreateAsync(solicitud);

            var response = new SolicitudResponseDto(
                creado.Id,
                creado.FechaCreacion,
                creado.Monto,
                creado.Moneda,
                new BeneficiarioResponseDto(
    creado.Beneficiario.Id,
    creado.Beneficiario.Nombre,
    creado.Beneficiario.Apellido,
    creado.Beneficiario.Cui,
    creado.Beneficiario.FuenteFinanciamientoId.HasValue
        ? new FuenteFinanciamientoDto(creado.Beneficiario.FuenteFinanciamientoId.Value, "")
        : null,
    creado.Beneficiario.EstructuraPresupuestariaId.HasValue
        ? new EstructuraPresupuestariaDto(creado.Beneficiario.EstructuraPresupuestariaId.Value, "")
        : null,
    creado.Beneficiario.Cuentas.Select(c => new CuentaResponseDto(c.Id, c.NumeroCuenta, c.Proposito)).ToList(),
    creado.Beneficiario.DocumentosRespaldo.Select(d => new DocumentoRespaldoResponseDto(d.Id, d.Descripcion)).ToList()
)

            );

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetById(int id)
        {
            var cliente = await _service.GetByIdAsync(id);
            return cliente is null ? NotFound() : Ok(cliente);
        }

        [HttpGet]
        public async Task<ActionResult<List<SolicitudResponseDto>>> Get()
        {
            var solicitudes = await _service.GetAllAsync();
            return Ok(solicitudes);
        }
    }
}
