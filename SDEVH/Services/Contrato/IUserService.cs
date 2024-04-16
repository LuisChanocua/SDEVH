using Microsoft.EntityFrameworkCore;
using SDEVH.Models;

namespace SDEVH.Services.Contrato
{
    public interface IUserService
    {
        Task<Usuario> GetUsuario(string correo, string password);

        Task<Usuario> RegistrarUsuarioAsync(Usuario nuevoUsuario);

        Task RegistrarUsuarioHistorialAsync(Guid usuarioId, UsuarioHistorial nuevoHistorial);
    }
}
