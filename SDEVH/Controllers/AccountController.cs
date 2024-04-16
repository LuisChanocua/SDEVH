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
        public async Task<ActionResult> RegistrarUsuario(Usuario usuarioModel)
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
                        RegistradoPorUsuario = usuarioModel.UsuarioId,
                        FechaRegistroUsuario = DateTime.Now
                    };

                    UsuarioHistorial usuario_registrado_historial = await _userServices.RegistrarUsuarioHistorialAsync(usuario_creado.UsuarioId, usuarioHistorial);

                    // Retornar un ActionResult indicando que la operación se ha completado exitosamente
                    return Json(new { success = true, message = "Usuario registrado correctamente." });
                }
                else
                {
                    // Retornar un ActionResult indicando que no se pudo crear el usuario
                    return Json(new { success = false, message = "No se pudo crear el usuario." });
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción e indicar que ha ocurrido un error
                Console.WriteLine(ex.Message);
                return Json(new { success = false, message = "Ha ocurrido un error al registrar el usuario: " + ex.Message });
            }
        }

    }
}
