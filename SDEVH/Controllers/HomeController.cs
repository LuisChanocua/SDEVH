using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SDEVH.Models;
using System.Diagnostics;

namespace SDEVH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SdevhContext _dbcontext;

        public HomeController(ILogger<HomeController> logger, SdevhContext context)
        {
            _logger = logger;
            _dbcontext = context;
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
            try
            {
                var dataUsuarios = _dbcontext.Usuario.ToList();

                ViewBag.DataUsuarios = dataUsuarios;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


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

       
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
