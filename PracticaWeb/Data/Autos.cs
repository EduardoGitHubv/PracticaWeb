using Dapper;
using PracticaWeb.Data.DataAccess;
using PracticaWeb.Models;
using PracticaWeb.Data.Resorces;
using System.Data;

namespace PracticaWeb.Data
{
	public class Autos : IAutos
	{
		private readonly SqlDataAccess _access;
		public Autos(SqlDataAccess access)
		{
			_access = access;
		}
		public IEnumerable<Auto> AltaAutos(string NoPlaca)
		{
			using (var conexion = _access.GetConection())
			{
				var param = new DynamicParameters();
				param.Add("@NoPlaca", NoPlaca, DbType.String);
				return conexion.Query<Auto>("Sp_AddAuto", param, commandType: CommandType.StoredProcedure).ToList();
			}
		}

        public IEnumerable<Auto> BusquedaAutos()
        {
            using (var conexion = _access.GetConection())
            {
                return conexion.Query<Auto>("Sp_BusquedaAutos", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void EntradaAutos(int idAuto)
        {
            using (var conexion = _access.GetConection())
            {
                var param = new DynamicParameters();
                param.Add("@idAuto", idAuto, DbType.Int32);
                conexion.Execute("Sp_IngresoAutos", param, commandType: CommandType.StoredProcedure);
            }
            
        }
    }
}
