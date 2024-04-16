using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDEVH.Models;


[Table("Usuario")]
public partial class Usuario
{

    [Key]
    public Guid UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public string? Cargo { get; set; }

    public string? Tel { get; set; }
    
    public Usuario()
    {
        UsuarioId = Guid.NewGuid();
    }

}
