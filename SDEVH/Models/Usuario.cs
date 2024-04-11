using System;
using System.Collections.Generic;

namespace SDEVH.Models;

public partial class Usuario
{
    public Guid UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public string? Cargo { get; set; }

    public string? Tel { get; set; }

}
