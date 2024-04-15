

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SDEVH.Models
{
    public partial class SdevhContext : DbContext
    {
        //Modelos de tablas bd
        public DbSet<UsuarioHistorial> UsuarioHistorial { get; set; }

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
                entity.HasKey(e=> e.UsuarioId);

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

            //Tabla de historial de registro de usuarios
            modelBuilder.Entity<UsuarioHistorial>()
            .HasKey(uh => uh.IdRegistroUsuario); // Configura IdRegistroUsuario como clave primaria

            modelBuilder.Entity<UsuarioHistorial>()
                .HasOne(uh => uh.RegistradoPorUsuario) // Define la relación con Usuario
                .WithMany() // Un usuario puede tener varios registros en el historial
                .HasForeignKey(uh => uh.IdRegistroUsuario); // Configura IdRegistroUsuario como clave foránea


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
