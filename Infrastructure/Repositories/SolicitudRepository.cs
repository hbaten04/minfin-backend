using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly AppDbContext _context;

        public SolicitudRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Solicitud> AddAsync(Solicitud solicitud)
        {
            _context.Solicitud.Add(solicitud);
            await _context.SaveChangesAsync();
            return solicitud;
        }

        public async Task<Solicitud?> GetByIdAsync(int id) =>
           await _context.Solicitud.FindAsync(id);
    }
}
