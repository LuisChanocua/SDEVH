using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SDEVH.DTO;
using SDEVH.Models;
using SDEVH.Resources;
using System.Diagnostics;

using SDEVH.Services;

namespace SDEVH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SdevhContext _dbcontext;
        private readonly UserServices _userservice;


        public HomeController(ILogger<HomeController> logger, SdevhContext context, UserServices userServices)
        {
            _logger = logger;
            _dbcontext = context;
            _userservice = userServices;    
        }
        #region Views
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
            var dataUsuariosDTO = new List<UsuarioDTO>();
            try
            {
                var dataUsuarios = _dbcontext.Usuario.ToList();


                foreach (var u in dataUsuarios)
                {
                    var reporItem = new UsuarioDTO
                    {

                        Nombre = Utilidades.Base64Decode(u.Nombre),
                        Apellidos = Utilidades.Base64Decode(u.Apellidos),
                        Direccion = Utilidades.Base64Decode(u.Direccion),
                        Correo = Utilidades.Base64Decode(u.Correo),
                        Cargo = Utilidades.Base64Decode(u.Cargo),
                        Tel = Utilidades.Base64Decode(u.Tel),
                        Status = u.Status

                    };

                    dataUsuariosDTO.Add(reporItem);
                }
                ViewBag.DataUsuarios = dataUsuariosDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Error500");
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
        #endregion

        #region UsuariosFuctions
        public async Task<ActionResult> EditarDatosUsusario(Guid UsuarioId)
        {
            Usuario usuario_data = await _userservice.GetDatosUsuarioAsync(UsuarioId);
            ViewBag.UsuarioData = usuario_data;

            return View();
        }


        #endregion



    }
}
