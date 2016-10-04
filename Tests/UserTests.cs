namespace Tests
{
    #region Usings
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Entities;
    #endregion

    #region TestClasses
    [TestClass]
    public class UserTests
    {
        #region Tests
        /// <summary>
        /// Tests the constructor in User
        /// </summary>
        [TestMethod]
        public void UserConstructorTest()
        {
            //  Arrange
            string username = "AspIT";
            string password = "1234";

            //  Act
            User user = new User(username, password);

            //  Assert
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(password, user.Password);
        }
        #endregion
    } 
    #endregion
}
