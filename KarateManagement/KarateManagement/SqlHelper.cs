using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarateManagement.Properties;
using MySql.Data.MySqlClient;


namespace KarateManagement
{
    /// <summary>
    /// This class is used to Create and initialize the database, as well as any other maitanance functions
    /// </summary>
    public static class SqlHelper
    {
        private static MySqlConnection m_connection;
        
        public static void Connect(string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                m_connection = connection;

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
        }

        public static void CreateDB()
        {
            try
            {
                string createDB = String.Format(Resources.CreateDB, "KarateManagement"); 
                MySqlCommand cmd = new MySqlCommand(createDB, m_connection);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
