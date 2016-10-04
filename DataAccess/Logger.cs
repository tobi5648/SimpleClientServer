namespace DataAccess
{
    #region Using
    using System;
    using System.IO;
    using System.Reflection;
    using System.Security;
    #endregion

    #region Classes
    /// <summary>
    /// The Logger class, which will handle the logfile
    /// </summary>
    public static class Logger
    {
        #region Constants
        /// <summary>
        /// the logfile to be used or created
        /// </summary>
        private static string logFile = @"\logfile.txt";
        #endregion

        #region Fields
        /// <summary>
        /// Gets the path to the logfile.txt
        /// </summary>
        private static readonly string exePath;

        /// <summary>
        /// This will allow the methods to write in a textfile, where the log is
        /// </summary>
        private static StreamWriter log;
        #endregion

        #region Methods
        /// <summary>
        /// Writes in the log when a client logs on
        /// </summary>
        /// <param name="message">This is the message to be logged in the log, holding the username, prefferable the message should be; {User} has logged in</param>
        public static void LogUserLogin(string message)
        {
            try
            {
                if (!File.Exists(exePath + logFile))
                {
                    log = new StreamWriter(exePath + logFile);
                }
                else
                {
                    log = File.AppendText(exePath + logFile);
                }

                log.Write("Date Time: " + DateTime.Now);
                log.WriteLine(", Client: " + message);
            }
            catch (UnauthorizedAccessException) { throw; }
            catch (ArgumentNullException) { throw; }
            catch (ArgumentException) { throw; }
            catch (DirectoryNotFoundException) { throw; }
            catch (PathTooLongException) { throw; }
            catch (IOException) { throw; }
            catch (SecurityException) { throw; }
            catch (NotSupportedException) { throw; }
            catch (ObjectDisposedException) { throw; }
            catch (Exception) { throw; }
            finally
            {
                log.Close();
            }
        }

        /// <summary>
        /// Writes in the log when an Exception occurs
        /// </summary>
        /// <param name="message">This is the message to be logged in the log, holding the exceptin, prefferable the message should be the Exception.message</param>
        public static void LogException(string message)
        {
            try
            {
                if (!File.Exists(exePath + logFile))
                {
                    log = new StreamWriter(exePath + logFile);
                }
                else
                {
                    log = File.AppendText(exePath + logFile);
                }

                log.Write("Date Time: " + DateTime.Now);
                log.WriteLine(", Exception: " + message);
            }
            catch (UnauthorizedAccessException) { throw; }
            catch (ArgumentNullException) { throw; }
            catch (ArgumentException) { throw; }
            catch (DirectoryNotFoundException) { throw; }
            catch (PathTooLongException) { throw; }
            catch (IOException) { throw; }
            catch (SecurityException) { throw; }
            catch (NotSupportedException) { throw; }
            catch (ObjectDisposedException) { throw; }
            catch (Exception) { throw; }
            finally
            {
                log.Close();
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// A static constructor for the class Logger. It finds the path to the logfile
        /// </summary>
        static Logger()
        {
            try
            {
                exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            catch (ArgumentException) { throw; }
            catch (PathTooLongException) { throw; }
            catch (NotSupportedException) { throw; }
            catch (Exception) { throw; }
           
        }
        #endregion
    }
    #endregion
}
