using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Repository
{
    public class UsersRepository : BaseRepository
    {

        public int Login(string username, string password)
        {
            int userId = 0;

            try
            {
                OpenConnection();

                string query = "SELECT id FROM users WHERE username = @username AND password = @password";

                using (MySqlCommand command = Connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    MySqlDataReader mdr = command.ExecuteReader();

                    while (mdr.Read())
                    {
                        userId = Convert.ToInt32(mdr[0]);
                    }

                    return userId;
                }
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
                userId = -1;
            } 
            finally
            {
                CloseConnection();
            }

            return userId;
        }
    }
}
