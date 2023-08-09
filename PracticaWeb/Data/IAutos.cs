using PracticaWeb.Models;

namespace PracticaWeb.Data
{
	public interface IAutos
	{
		IEnumerable<Auto> AltaAutos(string NoPlaca);
		IEnumerable<Auto> BusquedaAutos();
		void EntradaAutos(int idAuto);
	}
}
