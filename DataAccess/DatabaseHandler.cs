namespace DataAccess
{
    #region Usings
    using Entities;
    using System;
    using System.Data;
    using System.Data.SqlClient;
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
        public bool CheckForUserWithPassword(User user, out string username, out string password)
        {
            username = string.Empty;
            password = string.Empty;
            storedProcedureQuery = "GetUser";
            try
            {
                using (connection)
                {
                    connection.Open();
                    reader = null;
                    using(command =  new SqlCommand(storedProcedureQuery, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar)).Value = user.Username;
                        command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar)).Value = user.Password;

                        reader = command.ExecuteReader();

                        try
                        {
                            while (reader.Read())
                            {
                                username = reader["username"].ToString();
                                password = reader["password"].ToString();
                            }
                            return true;
                        }
                        catch (ArgumentException ex)
                        {
                            Logger.LogException(ex.Message);
                            throw;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// A method to be used to check if the user exists
        /// </summary>
        /// <param name="user">The user to be checked</param>
        /// <param name="username">the username of the user</param>
        /// <returns></returns>
        public bool CheckForUserWithoutPassword(User user, out string username)
        {
            username = string.Empty;
            storedProcedureQuery = "GetUserWithoutPassword";

            using (connection)
            {
                connection.Open();
                reader = null;
                using (command = new SqlCommand(storedProcedureQuery, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar)).Value = user.Username;
                    reader = command.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            username = reader["username"].ToString();
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Logger.LogException(ex.Message);
                        throw;
                    }
                }
            }
        }
        #endregion
    } 
    #endregion
}
