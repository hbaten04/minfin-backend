using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISolicitudRepository
    {
        Task<Solicitud> AddAsync(Solicitud solicitud);
        Task<Solicitud?> GetByIdAsync(int id);
        Task<IEnumerable<Solicitud>> GetAllAsync();
    }
}
