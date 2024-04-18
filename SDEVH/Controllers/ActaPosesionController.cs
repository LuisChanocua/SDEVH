using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SDEVH.Controllers
{
    public class ActaPosesionController : Controller
    {
        [Authorize(Policy = "AdminRole")]
        public IActionResult GenerarActaPosesion()
        {
            return View();
        }

        public IActionResult IngresarMedidasPosesion()
        {
            return View();
        }

        [Authorize(Policy = "AdminRole")]
        public IActionResult VistaPreviaActaPosesion()
        {
            return View();
        }

        [Authorize(Policy = "AdminRole")]
        public IActionResult EditarActaPosesion()
        {
            return View();
        }

        [Authorize(Policy = "AdminRole")]
        public IActionResult SubirArchivosActaPosesion()
        {
            return View();
        }

        [Authorize(Policy = "AdminRole")]
        public IActionResult EstadoDelActa()
        {
            return View();
        }

    }
}
