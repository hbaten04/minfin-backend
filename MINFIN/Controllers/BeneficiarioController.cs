using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MINFIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class BeneficiarioController : ControllerBase
    {
        private readonly IBeneficiarioService _service;

        public BeneficiarioController(IBeneficiarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<BeneficiarioResponseDto>> Create([FromBody] BeneficiarioDto dto)
        {
            // Mapear DTO a entidad EF Core
            var beneficiario = new Beneficiario
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Cui = dto.Cui,
                FuenteFinanciamientoId = dto.FuenteFinanciamientoId,
                EstructuraPresupuestariaId = dto.EstructuraPresupuestariaId,
                Cuentas = dto.Cuentas.Select(c => new CuentaBancaria
                {
                    NumeroCuenta = c.NumeroCuenta,
                    Proposito = c.Proposito
                }).ToList(),
                DocumentosRespaldo = dto.DocumentosRespaldo.Select(d => new DocumentosRespaldo
                {
                    Descripcion = d.Descripcion
                }).ToList()
            };

            var creado = await _service.CreateAsync(beneficiario);

            // Mapear entidad a DTO de salida
            var response = new BeneficiarioResponseDto(
                creado.Id,
                creado.Nombre,
                creado.Apellido,
                creado.Cui,
                creado.FuenteFinanciamiento != null
                    ? new FuenteFinanciamientoDto(creado.FuenteFinanciamiento.Id, creado.FuenteFinanciamiento.Descripcion)
                    : null,
                creado.EstructuraPresupuestaria != null
                    ? new EstructuraPresupuestariaDto(creado.EstructuraPresupuestaria.Id, creado.EstructuraPresupuestaria.Descripcion)
                    : null,
                creado.Cuentas.Select(c => new CuentaResponseDto(c.Id, c.NumeroCuenta, c.Proposito)).ToList(),
                creado.DocumentosRespaldo.Select(d => new DocumentoRespaldoResponseDto(d.Id, d.Descripcion)).ToList()
            );

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Beneficiario>> GetById(int id)
        {
            var cliente = await _service.GetByIdAsync(id);
            return cliente is null ? NotFound() : Ok(cliente);
        }
    }
}
