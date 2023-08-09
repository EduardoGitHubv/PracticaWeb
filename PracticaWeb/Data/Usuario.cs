using Dapper;
using PracticaWeb.Data.DataAccess;
using PracticaWeb.Models;
using PracticaWeb.Data.Resorces;
using System.Data;

namespace PracticaWeb.Data
{

    public class Usuario : IUsuario
	{
		private readonly SqlDataAccess _access;
		public Usuario(SqlDataAccess access)
		{
			_access = access;	
		}
		public IEnumerable<Login> ObtenerUsusario(string email, string password)
		{
			using(var conexion = _access.GetConection()) {
				var param = new DynamicParameters();
				param.Add("@Email", email, DbType.String);
				param.Add("@Password", password, DbType.String);
				return conexion.Query<Login>("Sp_GetUsuario", param, commandType: CommandType.StoredProcedure).ToList();
			}
		}

	}
}
