﻿namespace SDEVH.DTO
{
    public class UsuarioDTO
    {
        public Guid UsuarioId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellidos { get; set; }

        public string? Direccion { get; set; }

        public string? Correo { get; set; }

        public string? Password { get; set; }

        public string? Cargo { get; set; }

        public string? Tel { get; set; }

        public int? Status { get; set; }
    }
}
