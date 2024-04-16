using SDEVH.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace SDEVH.Services
{
    public class UserServices
    {
        private readonly SdevhContext _dbcontext;

        public UserServices(SdevhContext context)
        {
            //contexto de la bd
            _dbcontext = context;
        }

        /*Consultar usuario*/    
        public async Task<Usuario> GetUsuarioAsync(string correo, string password)
        {
            Usuario usuario_encontrado = await _dbcontext.Usuario.Where(x=> x.Correo == correo && x.Password == password).FirstOrDefaultAsync();


            return usuario_encontrado;
        }

        /*Registrar Usuario*/
        public async Task<Usuario> RegistrarUsuarioAsync(Usuario nuevoUsuario)
        {
            _dbcontext.Usuario.Add(nuevoUsuario);
            await _dbcontext.SaveChangesAsync();
            return nuevoUsuario;
        }

        /*Registrar el historial de quien registro el Usuario*/
        public async Task <UsuarioHistorial> RegistrarUsuarioHistorialAsync(Guid usuarioId, UsuarioHistorial nuevoHistorialUsurio)
        {
            nuevoHistorialUsurio.IdRegistroUsuario = usuarioId;
            _dbcontext.UsuarioHistorial.Add(nuevoHistorialUsurio);
            await _dbcontext.SaveChangesAsync();

            return nuevoHistorialUsurio;
        }
    }
}
