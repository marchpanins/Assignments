using Assignments.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Repository
{
    public class AssignmentsRepository : BaseRepository
    {
        public bool AddAssignment(Assignment assignment)
        {
            try
            {
                OpenConnection();

                string query = "INSERT INTO assignments (name, urgency_level, due_date, user_id) VALUES (@name, @urgencyLevel, @dueDate, @userId)";

                using (MySqlCommand command = Connection.CreateCommand())
                {
                    command.CommandText = query;

                    command.Parameters.AddWithValue("@name", assignment.Name);
                    command.Parameters.AddWithValue("@urgencyLevel", assignment.UrgencyLevel);
                    command.Parameters.AddWithValue("@dueDate", assignment.DueDate);
                    command.Parameters.AddWithValue("@userId", assignment.UserId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable GetByUserId(int userId)
        {
            List<Assignment> assignments = new List<Assignment>();

            try
            {
                OpenConnection();

                string query = "SELECT name, urgency_level, due_date FROM assignments WHERE user_id = @userId";

                using (MySqlCommand command = Connection.CreateCommand())
                {
                    command.CommandText = query;

                    command.Parameters.AddWithValue("@userId", userId);

                    DataTable dt = new DataTable();

                    MySqlDataAdapter sda = new MySqlDataAdapter(command);
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting assignments: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return null;
        }

    }
}
