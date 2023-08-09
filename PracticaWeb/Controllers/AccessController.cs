using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using PracticaWeb.Models;
using PracticaWeb.Data;
using PracticaWeb.Data.Resorces;

namespace PracticaWeb.Controllers
{
	public class AccessController : Controller
	{
		private readonly IUsuario _usuario;
		public AccessController(IUsuario usuario)
		{
			_usuario = usuario;
		}

		public IActionResult Login()
		{
			ClaimsPrincipal claimsPrincipal = HttpContext.User;
			if (claimsPrincipal.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(string email, string password)
		{
			IEnumerable<Login> login = _usuario.ObtenerUsusario(email, Utilidades.EncryptClave(password));

			if (login.Count() == 0 )
			{
				ViewData["Mensaje"] = "Usuario no encontrado";
				return View();

			}
			List<Claim> claim = new List<Claim>(){
				new Claim(ClaimTypes.NameIdentifier, email)
				};
			ClaimsIdentity claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
			AuthenticationProperties authenticationProperties = new AuthenticationProperties()
			{
				AllowRefresh = true
			};

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity),
				authenticationProperties
				);
			return RedirectToAction("Index", "Home");

			
		}
	}
}
