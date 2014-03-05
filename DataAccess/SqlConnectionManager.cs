using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public class SqlConnectionManager
    {
        private readonly SqlConnection sqlConnection;

        public SqlConnectionManager()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }

        public void ClosConnection()
        {
            sqlConnection.Close();
        }

        public SqlConnection OpenConnection()
        {
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}