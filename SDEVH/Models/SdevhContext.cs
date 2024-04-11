

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SDEVH.Models
{
    public partial class SdevhContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public SdevhContext()
        {
        }

        public SdevhContext(DbContextOptions<SdevhContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
