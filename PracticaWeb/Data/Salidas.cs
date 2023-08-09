using Dapper;
using PracticaWeb.Data.DataAccess;
using PracticaWeb.Models;
using System.Data;

namespace PracticaWeb.Data
{
    public class Salidas : ISalidas
    {
        private readonly SqlDataAccess _access;
        public Salidas(SqlDataAccess access)
        {
            _access = access;
        }
        public IEnumerable<Salidas> BusquedaEntradas()
        {
            using (var conexion = _access.GetConection())
            {
                return conexion.Query<Salidas>("Sp_BusquedaEntradas", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void SalidaAutos(int idServicio)
        {
            using (var conexion = _access.GetConection())
            {
                var param = new DynamicParameters();
                param.Add("@idServicio", idServicio, DbType.Int32);
                conexion.Execute("Sp_SalidaAutos", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
