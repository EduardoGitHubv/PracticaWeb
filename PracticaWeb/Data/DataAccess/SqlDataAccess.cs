using System.Data.SqlClient;

namespace PracticaWeb.Data.DataAccess
{
    public class SqlDataAccess
    {
        private readonly string _sqlConnection;

        public SqlDataAccess(string sqlConnection)
        {
            _sqlConnection = sqlConnection;

        }
        public SqlConnection GetConection()
        {
            var conn = new SqlConnection(_sqlConnection);
            conn.Open();
            return conn;
        }
    }
}
