using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISolicitudService
    {
        Task<Solicitud> CreateAsync(Solicitud solicitud);
        Task<Solicitud?> GetByIdAsync(int id);
        Task<IEnumerable<SolicitudResponseDto>> GetAllAsync();
    }
}
