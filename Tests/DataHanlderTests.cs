namespace Tests
{
    #region Usings
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataAccess;
    using Entities;
    #endregion

    #region TestClasses
    [TestClass]
    public class DataHanlderTests
    {
        #region Tests
        /// <summary>
        /// Tests if the method can find a user
        /// </summary>
        [TestMethod]
        public void GetUserWithoutPasswordTest()
        {
            //  Arrange
            DatabaseHandler dbHandler = new DatabaseHandler();
            User user = new User("Mads", "1234");
            string username;

            //  Act
            dbHandler.CheckForUserWithoutPassword(user, out username);

            //  Assert
            Assert.AreEqual(user.Username, username);
        } 

        /// <summary>
        /// Tests if nothing is returned when wrong pasword is used
        /// </summary>
        [TestMethod]
        public void GetUserWithWrongPasswordTest()
        {
            //  Arrange
            DatabaseHandler dbHandler = new DatabaseHandler();
            User user = new User("Mads", "123");
            string username;
            string password;

            //  Act
            dbHandler.CheckForUserWithPassword(user, out username, out password);

            //  Assert
            Assert.AreEqual(username, "");
            Assert.AreEqual(password, "");
        }
        
        /// <summary>
        /// Tests if method can find a user with a password
        /// </summary>
        [TestMethod]
        public void GetUserWithPasswordTest()
        {
            //  Arrange
            DatabaseHandler dbHandler = new DatabaseHandler();
            User user = new User("Mads", "1234");
            string username;
            string password;

            //  Act
            dbHandler.CheckForUserWithPassword(user, out username, out password);

            //  Assert
            Assert.AreEqual(user.Username, username);
            Assert.AreEqual(user.Password, password);
        }
        #endregion
    } 
    #endregion
}
