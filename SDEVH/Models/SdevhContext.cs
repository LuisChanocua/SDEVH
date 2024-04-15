

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
        public DbSet<Usuario> Usuario { get; set; }

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
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
