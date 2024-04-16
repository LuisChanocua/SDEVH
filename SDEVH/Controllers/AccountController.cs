using Microsoft.AspNetCore.Mvc;
using SDEVH.Models;
using SDEVH.Services;

/*Autenticacion referencias*/
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using SDEVH.Resources;

namespace SDEVH.Controllers
{
    public class AccountController : Controller
    {
        /*Para usar servicios de usuarios*/
        private readonly UserServices _userServices;

        public AccountController(UserServices userServices)
        {
            _userServices = userServices;
        }

        #region Views

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        #endregion


        //Registro de usuario
        [HttpPost]
        public async ActionResult RegistrarUsuario(Usuario usuarioModel)
        {

            try
            {
                /*Codificar data*/
                usuarioModel.Nombre = Utilidades.ToBase64Encode(usuarioModel.Nombre);
                usuarioModel.Apellidos = Utilidades.ToBase64Encode(usuarioModel.Apellidos);
                usuarioModel.Direccion = Utilidades.ToBase64Encode(usuarioModel.Direccion);
                usuarioModel.Password = Utilidades.ToBase64Encode(usuarioModel.Password);
                usuarioModel.Tel = Utilidades.ToBase64Encode(usuarioModel.Tel);
                


                Usuario usuario_creado = await _userServices.RegistrarUsuarioAsync(usuarioModel);
                if (usuario_creado != null)
                {
                    /* Crear registro en el historial de usuario */
                    UsuarioHistorial usuarioHistorial = new UsuarioHistorial
                    {
                        IdRegistroUsuario = Guid.NewGuid(),
                        RegistradoPorUsuario = usuarioModel.UsuarioId,
                        FechaRegistroUsuario = DateTime.Now
                       
                    };

                    UsuarioHistorial usuario_registrado_historial = await _userServices.RegistrarUsuarioHistorialAsync(usuario_creado.UsuarioId, usuarioHistorial);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new
                {
                    success = true,
                    message = "Envio de datos al controlador pero sin realizar ninguna operación: " + ex
                });
            }
        }
    }
}
