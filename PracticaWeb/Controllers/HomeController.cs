using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using PracticaWeb.Data;
using PracticaWeb.Data.Resorces;
using PracticaWeb.Models;
using System.Diagnostics;

namespace PracticaWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAutos _autos;
        public HomeController(IAutos autos) { 
            _autos = autos;
        }

        public IActionResult Index()
        {
            var autos = _autos.BusquedaAutos();
            return View(autos);
        }
        public IActionResult AltaAutos()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AltaAutos(string NoPlaca) {
			IEnumerable<Auto> autos = _autos.AltaAutos(NoPlaca);
			if (autos.Count() == 0)
			{
				return RedirectToAction("Index", "Home");

			}
			ViewData["Mensaje"] = "El auto ya existe";
			return View();
		}

        public async Task<IActionResult> EntradaAutos(int id) {
             _autos.EntradaAutos(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> LogOut() { 
         await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");
        }
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}