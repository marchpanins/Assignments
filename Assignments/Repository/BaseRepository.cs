using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Assignments.Repository
{
   
    public abstract class BaseRepository
    {
        protected MySqlConnection Connection { get; private set; }

        protected BaseRepository()
        {
            Connection = new MySqlConnection(StaticDetails.ConnectionString);
        }

        protected void OpenConnection()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }

        protected void CloseConnection()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }

        public string ErrorMessage { get; set; }
    }
}
