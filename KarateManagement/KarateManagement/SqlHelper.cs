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
            MySqlConnection connection = new MySqlConnection(connectionString);
            
            connection.Open();

            m_connection = connection;

            Console.WriteLine("State: {0}", connection.State);
            Console.WriteLine("ConnectionString: {0}",
                connection.ConnectionString);

            string createDB = String.Format(Resources.CreateDB, "KarateManagement");
            MySqlCommand cmd = new MySqlCommand(createDB, connection);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Created DB");
            
        }

        public static void CreateDB()
        {
            try
            {
                string createDB = String.Format(Resources.CreateDB, "KarateManagement"); 
                MySqlCommand cmd = new MySqlCommand(createDB, m_connection);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Created DB");

            }
            catch (Exception e)
            {
                //TODO; Maybe log the exception
                throw e;
            }
        }

        public static void CreateTable()
        {
            try
            {
                string createTable = String.Format(Resources.CreateTable, "KarateManagement");
                MySqlCommand cmd = new MySqlCommand(createTable, m_connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //TODO; Maybe log the exception
                throw e;
            }
        }


        public static void Create(Student student)
        {
            
        }

        public static void Read(int[] id)
        {
            
        }

        public static void Update(int id)
        {
            
        }

        public static void Delete(int id)
        {
            
        }
    }
}
