using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SDEVH.Models;
using System.Diagnostics;

namespace SDEVH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomePresidente()
        {
            return View();
        }

        public IActionResult ControlUsuarios()
        {
            return View();
        }

        public IActionResult EstadoActaPresidente()
        {
            return View();
        }

        public IActionResult EncontrarTerreno()
        {
            return View();
        }

        public IActionResult NotificacionActas()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
