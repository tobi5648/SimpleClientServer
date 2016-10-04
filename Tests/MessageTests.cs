namespace Tests
{
    #region UsingsS
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Entities;
    #endregion

    #region TestClasses
    [TestClass]
    public class MessageTests
    {
        #region Tests
        [TestMethod]
        public void MessageConstructorTests()
        {
            //  Arrange
            User sender = new User("AspITLærer", "1234");
            User receiver = new User("AspITElev", "123");
            string content = "Hej";

            //  Act
            Message message = new Message(content, sender, receiver);

            //  Assert
            Assert.AreEqual(content, message.Content);
            Assert.AreEqual(sender, message.Sender);
            Assert.AreEqual(receiver, message.Receiver);
        } 
        #endregion
    } 
    #endregion
}
