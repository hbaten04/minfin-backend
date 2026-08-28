using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Beneficiario> Beneficiarios { get; set; }
        public DbSet<CuentaBancaria> Cuentas { get; set; }
        public DbSet<FuenteFinanciamiento> FuentesFinanciamiento { get; set; }
        public DbSet<EstructuraPresupuestaria> EstructurasPresupuestarias { get; set; }
        public DbSet<DocumentosRespaldo> DocumentosRespaldo { get; set; }
        public DbSet<Solicitud> Solicitud { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Beneficiario - Cuenta (1:N)
            modelBuilder.Entity<Beneficiario>()
                .HasMany(b => b.Cuentas)
                .WithOne(c => c.Beneficiario)
                .HasForeignKey(c => c.BeneficiarioId);

            // Beneficiario - FuenteFinanciamiento (N:1)
            modelBuilder.Entity<Beneficiario>()
                .HasOne(b => b.FuenteFinanciamiento)
                .WithMany(f => f.Beneficiarios)
                .HasForeignKey(b => b.FuenteFinanciamientoId);

            // Beneficiario - EstructuraPresupuestaria (N:1)
            modelBuilder.Entity<Beneficiario>()
                .HasOne(b => b.EstructuraPresupuestaria)
                .WithMany(e => e.Beneficiarios)
                .HasForeignKey(b => b.EstructuraPresupuestariaId);

            // Beneficiario - DocumentosRespaldo (1:N)
            modelBuilder.Entity<Beneficiario>()
                .HasMany(b => b.DocumentosRespaldo)
                .WithOne(d => d.Beneficiario)
                .HasForeignKey(d => d.BeneficiarioId);
        }
    }
}
