using SDEVH.Models;

namespace SDEVH.Services
{
    public class UserServices
    {
        private readonly SdevhContext _context;

        public UserServices(SdevhContext context)
        {
            //contexto de la bd
            _context = context;
        }

        /*Registrar Usuario*/
        public async Task<Usuario> RegistrarUsuarioAsync(Usuario nuevoUsuario)
        {
            _context.Usuario.Add(nuevoUsuario);
            await _context.SaveChangesAsync();
            return nuevoUsuario;
        }

        /*Registrar el historial de quien registro el Usuario*/
        public async Task RegistrarUsuarioHistorialAsync(Guid usuarioId, UsuarioHistorial nuevoHistorial)
        {
            nuevoHistorial.IdRegistroUsuario = usuarioId;
            _context.UsuarioHistorial.Add(nuevoHistorial);
            await _context.SaveChangesAsync();
        }
    }
}
