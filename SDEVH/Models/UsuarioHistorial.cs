using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDEVH.Models
{
    [Table("UsuarioHistorial")]
    public class UsuarioHistorial
    {
        
        [Key]
        public Guid IdRegistroUsuario { get; set; }
        public Usuario? RegistradoPorUsuario { get; set; }
        public DateTime? FechaRegistroUsuario { get; set; }
    }
}
