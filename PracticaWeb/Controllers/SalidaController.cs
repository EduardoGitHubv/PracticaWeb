using Microsoft.AspNetCore.Mvc;
using PracticaWeb.Data;

namespace PracticaWeb.Controllers
{
    public class SalidaController : Controller
    {
        private readonly ISalidas _salidas;
        public SalidaController(ISalidas salidas)
        {
            _salidas = salidas;
        }
        public IActionResult Index()
        {
            var autos = _salidas.BusquedaEntradas();
            return View(autos);
        }
    }
}
