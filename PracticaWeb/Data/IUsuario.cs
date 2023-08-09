using PracticaWeb.Models;
namespace PracticaWeb.Data
{
	public interface IUsuario
	{
		IEnumerable<Login> ObtenerUsusario(string email, string password);
	}
}
