namespace DataAccess
{
    #region Usings
    using Entities;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Security;
    #endregion

    #region Classes
    /// <summary>
    /// Handles access to the database
    /// </summary>
    public class DatabaseHandler
    {
        #region Fields
        /// <summary>
        /// Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database 
        /// </summary>
        private SqlCommand command;

        /// <summary>
        /// The string which will hold the connection to the database
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Represents an open connection to a SQL Server database
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// This will hold which stored procedure to be used
        /// </summary>
        private string storedProcedureQuery;

        /// <summary>
        /// Provides a way of reading a forward-only stream of rows from a SQL Server database
        /// </summary>
        private SqlDataReader reader;
        #endregion

        #region Constructors

        /// <summary>
        /// A static constructor to be run once, when the class is used
        /// </summary>
        static DatabaseHandler()
        {
        }

        /// <summary>
        /// A constructor of the class, which tests the connection, and sets the connection string
        /// </summary>
        public DatabaseHandler()
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SimpleClientServerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex.Message);
                throw;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// A method to be used to check if the user and the corresponding password exists
        /// </summary>
        /// <param name="user">The user trying to log on</param>
        /// <param name="username">the users username</param>
        /// <param name="password">the users password</param>
        /// <returns>The username and password, and tru/false depending on existance</returns>
        public bool CheckForUserWithPassword(out User user, string username, string password)
        {
            storedProcedureQuery = "GetUser";
            try
            {
                using (connection)
                {
                    connection.Open();
                    reader = null;
                    using(command =  new SqlCommand(storedProcedureQuery, connection))
                    {
                        user = null;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar)).Value = username;
                        command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar)).Value = password;

                        reader = command.ExecuteReader();

                        try
                        {
                            while (reader.Read())
                            {
                                user.Username = reader["username"].ToString();
                                user.Password = reader["password"].ToString();
                            }
                            Logger.LogUserLogin(user.Username);
                            return true;
                        }
                        catch (SqlException ex) { Logger.LogException(ex.Message); throw; }
                        catch (UnauthorizedAccessException ex) { Logger.LogException(ex.Message); throw; }
                        catch (ArgumentNullException ex) { Logger.LogException(ex.Message); throw; }
                        catch (ArgumentException ex) { Logger.LogException(ex.Message); throw; }
                        catch (DirectoryNotFoundException ex) { Logger.LogException(ex.Message); throw; }
                        catch (PathTooLongException ex) { Logger.LogException(ex.Message); throw; }
                        catch (IOException ex) { Logger.LogException(ex.Message); throw; }
                        catch (SecurityException ex) { Logger.LogException(ex.Message); throw; }
                        catch (NotSupportedException ex) { Logger.LogException(ex.Message); throw; }
                        catch (ObjectDisposedException ex) { Logger.LogException(ex.Message); throw; }
                        catch (Exception ex) { Logger.LogException(ex.Message); throw; }
                    }

                }
            }
            catch (IOException ex) { Logger.LogException(ex.Message); throw; }
            catch (ObjectDisposedException ex) { Logger.LogException(ex.Message); throw; }
            catch (InvalidCastException ex) { Logger.LogException(ex.Message); throw; }
            catch (ArgumentNullException ex) { Logger.LogException(ex.Message); throw; }
            catch (ArgumentException ex) { Logger.LogException(ex.Message); throw; }
            catch (InvalidOperationException ex) { Logger.LogException(ex.Message); throw; }
            catch (ConfigurationException ex) { Logger.LogException(ex.Message); throw; }
            catch (SqlException ex) { Logger.LogException(ex.Message); throw; }
            catch (Exception ex) { Logger.LogException(ex.Message); throw; }
        }

        /// <summary>
        /// A method to be used to check if the user exists
        /// </summary>
        /// <param name="user">The user to be checked</param>
        /// <param name="username">the username of the user</param>
        /// <returns></returns>
        public bool CheckForUserWithoutPassword(out User user, string username)
        {
            user = null;
            storedProcedureQuery = "GetUserWithoutPassword";

            using (connection)
            {
                try
                {
                    connection.Open();
                    reader = null;
                    using (command = new SqlCommand(storedProcedureQuery, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar)).Value = username;
                        reader = command.ExecuteReader();

                        try
                        {
                            while (reader.Read())
                            {
                                user.Username = reader["username"].ToString();
                            }

                            Logger.LogUserLogin(user.Username);
                            return true;
                        }
                        catch (SqlException ex) { Logger.LogException(ex.Message); throw; }
                        catch (UnauthorizedAccessException ex) { Logger.LogException(ex.Message); throw; }
                        catch (ArgumentNullException ex) { Logger.LogException(ex.Message); throw; }
                        catch (ArgumentException ex) { Logger.LogException(ex.Message); throw; }
                        catch (DirectoryNotFoundException ex) { Logger.LogException(ex.Message); throw; }
                        catch (PathTooLongException ex) { Logger.LogException(ex.Message); throw; }
                        catch (IOException ex) { Logger.LogException(ex.Message); throw; }
                        catch (SecurityException ex) { Logger.LogException(ex.Message); throw; }
                        catch (NotSupportedException ex) { Logger.LogException(ex.Message); throw; }
                        catch (ObjectDisposedException ex) { Logger.LogException(ex.Message); throw; }
                        catch (Exception ex) { Logger.LogException(ex.Message); throw; }
                    }
                }
                catch (IOException ex) { Logger.LogException(ex.Message); throw; }
                catch (ObjectDisposedException ex) { Logger.LogException(ex.Message); throw; }
                catch (InvalidCastException ex) { Logger.LogException(ex.Message); throw; }
                catch (ArgumentNullException ex) { Logger.LogException(ex.Message); throw; }
                catch (ArgumentException ex) { Logger.LogException(ex.Message); throw; }
                catch (InvalidOperationException ex) { Logger.LogException(ex.Message); throw; }
                catch (ConfigurationException ex) { Logger.LogException(ex.Message); throw; }
                catch (SqlException ex) { Logger.LogException(ex.Message); throw; }
                catch (Exception ex) { Logger.LogException(ex.Message); throw; }
            }
        }
        #endregion
    } 
    #endregion
}
