using Microsoft.AspNetCore.Mvc;
using SDEVH.Models;
using SDEVH.Services;

namespace SDEVH.Controllers
{
    public class AccountController : Controller
    {
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
        public ActionResult RegistrarUsuario(Usuario usuarioModel)
        {


            return Json(new { 
                success = true,
                message = "Envio de datos al controlador"
            });
        }
    }
}
