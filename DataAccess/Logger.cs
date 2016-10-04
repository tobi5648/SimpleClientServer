namespace DataAccess
{
    #region Using
    using System;
    using System.IO;
    using System.Reflection;
    #endregion

    #region Classes
    /// <summary>
    /// The Logger class, which will handle the logfile
    /// </summary>
    public static class Logger
    {
        #region Fields
        /// <summary>
        /// Gets the path to the logfile.txt
        /// </summary>
        private static readonly string exePath;
        #endregion

        #region Methods
        /// <summary>
        /// Writes in the log when a client logs on
        /// </summary>
        /// <param name="message"></param>
        public static void LogUserLogin(string message)
        {
            StreamWriter log;

            if (!File.Exists(exePath + "\\" + "logfile.txt"))
            {
                log = new StreamWriter(exePath + "\\" + "logfile.txt");
            }
            else
            {
                log = File.AppendText(exePath + "\\" + "logfile.txt");
            }

            log.Write("Date Time: " + DateTime.Now);
            log.WriteLine(", Client: " + message);
            log.Close();
        }

        /// <summary>
        /// Writes in the log when an Exception occurs
        /// </summary>
        /// <param name="message"></param>
        public static void LogException(string message)
        {
            StreamWriter log;

            if (!File.Exists(exePath + "\\" + "logfile.txt"))
            {
                log = new StreamWriter(exePath + "\\" + "logfile.txt");
            }
            else
            {
                log = File.AppendText(exePath + "\\" + "logfile.txt");
            }
            log.Write("Date Time: " + DateTime.Now);

            if (message.Contains("logged"))
            {
                log.WriteLine(", Client: " + message);
            }
            if (message.Contains("Exception"))
            {
                log.WriteLine(", Exception Name: " + message);
            }

            log.Close();
        }
        #endregion

        #region Constructors
        /// <summary>
        /// A static constructor for the class Logger
        /// </summary>
        static Logger()
        {
            exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        #endregion
    } 
    #endregion
}
