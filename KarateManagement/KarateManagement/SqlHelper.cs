using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KarateManagement.Properties;
using MySql.Data.MySqlClient;


namespace KarateManagement
{
    /// <summary>
    ///     This class is used to Create and initialize the database, as well as any other maitanance functions
    /// </summary>
    public static class SqlHelper
    {
        private static MySqlConnection m_connection;

        public static async Task Connect(string connectionString)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            Task initializeDb = null;

            bool connected = false;
            try
            {
                await connection.OpenAsync();

                m_connection = connection;
                connected = true;

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);


                string useDB = String.Format("Use karatemanagement;");
                MySqlCommand cmd = new MySqlCommand(useDB, m_connection);
                await cmd.ExecuteNonQueryAsync();

                Console.WriteLine("Using KarateManagement");
            }
            catch (MySqlException e)
            {
                if (connected)
                    initializeDb = InitializeDB();
                else
                    ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (DbException e)
            {
                ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (Exception e)
            {
                ErrorLogger.Logger.Write(e.ToString(), true);
            }

            if (initializeDb != null)
            {
                await initializeDb;
            }
        }

        /// <summary>
        ///     This method should be called to create all the tables and use the table
        /// </summary>
        private static async Task InitializeDB()
        {
            //Database doesnt exist. Must create database. Disconnect and try again
            try
            {
                await CreateDB();

                string useDB = String.Format("Use karatemanagement;");
                MySqlCommand cmd = new MySqlCommand(useDB, m_connection);
                await cmd.ExecuteNonQueryAsync();

                await CreateTable();
            }
            catch (DbException e)
            {
                ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (Exception e)
            {
                ErrorLogger.Logger.Write(e.ToString(), true);
            }
        }

        /// <summary>
        ///     Creates a Database called "KarateManagement"
        /// </summary>
        /// <returns>An awaitable task that Creates a DB</returns>
        private static async Task CreateDB()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(Resources.CreateDB, m_connection);
                await cmd.ExecuteNonQueryAsync();
                Console.WriteLine("Creating DB");
            }
            catch (DbException e)
            {
                ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (Exception e)
            {
                ErrorLogger.Logger.Write(e.ToString(), true);
            }
        }

        private static async Task CreateTable()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(Resources.CreateTable, m_connection);
                await cmd.ExecuteNonQueryAsync();
            }
            catch (DbException e)
            {
                ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (Exception e)
            {
                ErrorLogger.Logger.Write(e.ToString(), true);
            }
        }

        /// <summary>
        ///     Creates a student in the database
        /// </summary>
        /// <param name="student">A student object to insert</param>
        public static async Task CreateStudent(Student student)
        {
            try
            {
                string createStudent = String.Format(Resources.CreateStudent, student.ID, student.FirstName,
                    student.LastName, student.DateOfBirth.ToString("yy-MM-dd"),
                    student.Address, student.PostalCode, student.PhoneNumber, student.Email, student.Hours, (int)student.Belt,
                    student.Balance, student.MembershipEndDate.ToString("yy-MM-dd"));
                MySqlCommand cmd = new MySqlCommand(createStudent, m_connection);
                Task<int> t = cmd.ExecuteNonQueryAsync();

                await t;
            }
            catch (DbException e)
            {
                ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (Exception e)
            {
                ErrorLogger.Logger.Write(e.ToString(), true);
            }
        }

        /// <summary>
        /// Gets the Highest Student ID in the database
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetHighestID()
        {
            string query = Resources.SelectMaxID;
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            int id = 0;

            try
            {
                Task<object> t = cmd.ExecuteScalarAsync();
                var obj = await t;

                if (DBNull.Value.Equals(obj))
                {
                    id = 0;
                }
                else
                {
                    id = Convert.ToInt32(obj);
                }
            }
            catch (InvalidOperationException e)
            {
                ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (DbException e)
            {
                ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (Exception e)
            {
                ErrorLogger.Logger.Write(e.ToString(), true);
            }

            return id;
        }

        /// <summary>
        /// Deletes a student from the database
        /// </summary>
        /// <param name="id">ID of the student to delete</param>
        /// <returns>A task that can be awaited</returns>
        public static async Task DeleteStudent(int id)
        {
            String deleteStudent = String.Format(Resources.DeleteStudent, id);
            MySqlCommand cmd = new MySqlCommand(deleteStudent, m_connection);

            try
            {
                await cmd.ExecuteNonQueryAsync();
                Console.WriteLine(String.Format("Deleting student #{0}", id));
            }
            catch (DbException e)
            {
                ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (Exception e)
            {
                ErrorLogger.Logger.Write(e.ToString(), true);
            }
        }

        /// <summary>
        /// Gets a Student object from the database
        /// </summary>
        /// <param name="id">The ID of the student</param>
        /// <returns>A student object with all its fields populated</returns>
        public static async Task<Student> GetStudent(int id)
        {
            string script = String.Format("select * from student where id = {0}", id);
            MySqlCommand cmd = new MySqlCommand(script, m_connection);
            DbDataReader reader;
            DataTable dt = new DataTable();
            Student s = new Student();

            try
            {
                reader = await cmd.ExecuteReaderAsync();

                dt.Load(reader);

                foreach (DataRow row in dt.Rows)
                {
                    s.ID = Convert.ToInt32(row["ID"].ToString());
                    s.FirstName = row["FirstName"].ToString();
                    s.LastName = row["LastName"].ToString();
                    s.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                    s.Address = row["Address"].ToString();
                    s.PhoneNumber = s.Address = row["PhoneNumber"].ToString();
                    s.PostalCode = row["PostalCode"].ToString();
                    s.Email = row["Email"].ToString();
                    s.Hours = Convert.ToInt32(row["Hours"].ToString());
                    s.Belt = (Belt)Convert.ToInt32(row["Belt"].ToString());
                    s.Balance = Convert.ToDecimal(row["Balance"].ToString());
                    s.MembershipEndDate = Convert.ToDateTime(row["MembershipEndDate"]);
                }
            }
            catch (DbException e)
            {
                ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (Exception e)
            {
                ErrorLogger.Logger.Write(e.ToString(), true);
            }

            return s;
        }

        /// <summary>
        /// Gets all the students in the database
        /// </summary>
        /// <returns>An array of students</returns>
        public static async Task<ArrayList> GetAllStudents()
        {
            return await GetStudents(Resources.GetAllStudents);
        }


        /// <summary>
        /// Gets students in the database based on the script
        /// </summary>
        /// <param name="script">The SQL script used to get students</param>
        /// <returns>An array of students</returns>
        public static async Task<ArrayList> GetStudents(String script)
        {
            MySqlCommand cmd = new MySqlCommand(script, m_connection);
            DbDataReader reader;
            DataTable dt = new DataTable();

            ArrayList array = new ArrayList();

            try
            {
                reader = await cmd.ExecuteReaderAsync();

                dt.Load(reader);

                foreach (DataRow row in dt.Rows)
                {
                    Student s = new Student();

                    s.ID = Convert.ToInt32(row["ID"].ToString());
                    s.FirstName = row["FirstName"].ToString();
                    s.LastName = row["LastName"].ToString();
                    s.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                    s.Address = row["Address"].ToString();
                    s.PhoneNumber = s.Address = row["PhoneNumber"].ToString();
                    s.PostalCode = row["PostalCode"].ToString();
                    s.Email = row["Email"].ToString();
                    s.Hours = Convert.ToInt32(row["Hours"].ToString());
                    s.Belt = (Belt)Convert.ToInt32(row["Belt"].ToString());
                    s.Balance = Convert.ToDecimal(row["Balance"].ToString());
                    s.MembershipEndDate = Convert.ToDateTime(row["MembershipEndDate"]);

                    array.Add(s);
                }
            }
            catch (DbException e)
            {
                ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (Exception e)
            {
                ErrorLogger.Logger.Write(e.ToString(), true);
            }

            return array;
        }

        /// <summary>
        /// Updates a student in the database
        /// </summary>
        /// <param name="student">A student object to update</param>
        public static async Task UpdateStudent(Student student)
        {
            try
            {
                string updateStudent = String.Format(Resources.UpdateStudent, student.ID, student.FirstName,
                    student.LastName, student.DateOfBirth.ToString("yy-MM-dd"),
                    student.Address, student.PostalCode, student.PhoneNumber, student.Email, student.Hours, (int)student.Belt,
                    student.Balance, student.MembershipEndDate.ToString("yy-MM-dd"));
                MySqlCommand cmd = new MySqlCommand(updateStudent, m_connection);
                Task<int> t = cmd.ExecuteNonQueryAsync();

                await t;
            }
            catch (DbException e)
            {
                ErrorLogger.Logger.Write(e.ToString(), false);
            }
            catch (Exception e)
            {
                ErrorLogger.Logger.Write(e.ToString(), true);
            }
        }

    }
}