using PracticaWeb.Models;

namespace PracticaWeb.Data
{
    public interface ISalidas
    {
        IEnumerable<Salidas> BusquedaEntradas();
        void SalidaAutos(int idAuto);
    }
}
