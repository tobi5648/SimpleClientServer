namespace Entities
{
    #region Usings
    using System;
    #endregion

    #region Classes
    /// <summary>
    /// This is the messages class
    /// </summary>
    public class Message
    {
        #region Fields
        /// <summary>
        /// The message to be send from sender to receiver
        /// </summary>
        private string content;

        /// <summary>
        /// The User that sends
        /// </summary>
        private User sender;

        /// <summary>
        /// The User that receives
        /// </summary>
        private User receiver;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the content
        /// </summary>
        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        /// <summary>
        /// Gets or sets the sender
        /// </summary>
        public User Sender
        {
            get
            {
                return sender;
            }

            set
            {
                sender = value;
            }
        }

        /// <summary>
        /// Gets or sets the receiver
        /// </summary>
        public User Receiver
        {
            get
            {
                return receiver;
            }

            set
            {
                receiver = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// The constructor for Message
        /// </summary>
        /// <param name="content">This is the message to be sent to the receiver</param>
        /// <param name="sender">This is the User that sends the message</param>
        /// <param name="receiver">This is the User that receives the message</param>
        /// <exception cref="Exception">This is catched if an exception happens</exception>
        public Message(string content, User sender, User receiver)
        {
            try
            {
                Content = content;
                Sender = sender;
                Receiver = receiver;
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
