namespace Entities
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion

    #region Classes
    public class User
    {
        #region Fields
        /// <summary>
        /// The username of the User
        /// </summary>
        private string username;

        /// <summary>
        /// The password of the User
        /// </summary>
        private string password;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the username of the User
        /// </summary>
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        /// <summary>
        /// Gets or sets the password of the User
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// A constructor for the User
        /// </summary>
        /// <param name="username">the users username</param>
        /// <param name="password">the users password</param>
        /// <exception cref="Exception"></exception>
        public User (string username, string password)
        {
            try
            {
                Username = username;
                Password = password;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    } 
    #endregion
}
