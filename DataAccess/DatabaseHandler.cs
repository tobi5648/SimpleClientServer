namespace DataAccess
{

    #region Usings
    using Entities;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    #endregion

    #region Classes
    public class DatabaseHandler
    {
        #region Fields
        private SqlCommand command;
        private readonly string connectionString;
        private SqlConnection connection;
        private string storedProcedureQuery;
        private SqlDataReader reader;
        #endregion

        #region Constructors
        static DatabaseHandler()
        {
        }

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
        public bool CheckForUserWithPassword(User user, out string username, out string password)
        {
            username = string.Empty;
            password = string.Empty;
            storedProcedureQuery = "GetUser";
            try
            {
                using (connection)
                {
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

        public bool CheckForUserWithoutPassword(User user, out string username)
        {
            username = string.Empty;
            storedProcedureQuery = "GetUserWithoutPassword";


        }
        #endregion
    } 
    #endregion
}
