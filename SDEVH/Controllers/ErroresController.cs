using Microsoft.AspNetCore.Mvc;

namespace SDEVH.Controllers
{
    public class ErroresController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }
    }
}
